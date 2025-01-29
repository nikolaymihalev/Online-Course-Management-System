using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Core.Constants;
using OnlineCourseSystem.Core.Contracts;
using OnlineCourseSystem.Core.Models.Course;
using OnlineCourseSystem.Infrastructure.Common;
using OnlineCourseSystem.Infrastructure.Models;

namespace OnlineCourseSystem.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository repository;

        public CourseService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddAsync(CourseFormModel model)
        {
            var entity = new Course()
            {
                Name = model.Name,
                Description = model.Description,
                MaxStudents = model.MaxStudents,
                EnrolledStudents = 0
            };

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseInfoModel>> GetCoursesAsync()
        {
            var allCourses = await repository.AllReadonly<Course>()
                .Select(x => new CourseInfoModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    MaxStudents = x.MaxStudents,
                    EnrolledStudents = x.EnrolledStudents,
                })
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return allCourses.Where(x => x.IsAvailable);
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await repository.DeleteAsync<Course>(id);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException(string.Format(Messages.DoesntExist, "Course"));
            }
        }

        public async Task EditAsync(CourseFormModel model)
        {
            var entity = await repository.GetByIdAsync<Course>(model.Id);

            if(entity is null)
                throw new ArgumentException(string.Format(Messages.DoesntExist, "Course"));

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.MaxStudents = model.MaxStudents;

            await repository.SaveChangesAsync();
        }

        public async Task<CourseInfoModel> GetByIdAsync(int id)
        {
            var model = await repository.GetByIdAsync<Course>(id);

            if(model is null)
                throw new ArgumentException(string.Format(Messages.DoesntExist, "Course"));

            return new CourseInfoModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                MaxStudents = model.MaxStudents,
                EnrolledStudents = model.EnrolledStudents,
            };
        }
    }
}
