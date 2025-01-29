using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Core.Constants;
using OnlineCourseSystem.Core.Contracts;
using OnlineCourseSystem.Core.Models.Student;
using OnlineCourseSystem.Infrastructure.Common;
using OnlineCourseSystem.Infrastructure.Models;

namespace OnlineCourseSystem.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository repository;

        public StudentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(StudentFormModel model)
        {
            var entity = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudentInfoModel>> GetAllStudentsAsync()
        {
            return await repository.AllReadonly<Student>()
                .Select(x => new StudentInfoModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                })
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await repository.DeleteAsync<Student>(id);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException(string.Format(Messages.DoesntExist, "Student"));
            }
        }

        public async Task EditAsync(StudentFormModel model)
        {
            var entity = await repository.GetByIdAsync<Student>(model.Id);

            if(entity is null)
                throw new ArgumentException(string.Format(Messages.DoesntExist, "Student"));

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;

            await repository.SaveChangesAsync();
        }

        public async Task<StudentInfoModel> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync<Student>(id);

            if (entity is null)
                throw new ArgumentException(string.Format(Messages.DoesntExist, "Student"));

            return new StudentInfoModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
            };
        }
    }
}
