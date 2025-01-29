using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Core.Constants;
using OnlineCourseSystem.Core.Contracts;
using OnlineCourseSystem.Core.Enums;
using OnlineCourseSystem.Core.Models.Student;
using OnlineCourseSystem.Infrastructure.Common;
using OnlineCourseSystem.Infrastructure.Models;

namespace OnlineCourseSystem.Core.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IRepository repository;

        public StudentCourseService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<StudentCourseModel>> GetStudentsCourses(int studentId)
        {
            return await repository.AllReadonly<StudentCourse>()
                .Where(x => x.StudentId == studentId)
                .Select(x => new StudentCourseModel()
                {
                    StudentId = x.StudentId,
                    CourseId = x.CourseId,
                    Progress = x.Progress,
                    EnrollmentDate = x.EnrollmentDate,
                })
                .OrderByDescending(x => x.EnrollmentDate)
                .ToListAsync();
        }

        public async Task LeaveCourse(int courseId, int studentId)
        {
            var entity = await repository.All<StudentCourse>()
                .FirstOrDefaultAsync(x => x.CourseId == courseId && x.StudentId == studentId);

            if (entity is null)
                throw new ArgumentException(string.Format(Messages.DoesntExist, "Student-Course"));

            var course = await repository.GetByIdAsync<Course>(courseId);

            if (course != null && course.EnrolledStudents > 0)
                course.EnrolledStudents--;
            repository.Delete(entity);

            await repository.SaveChangesAsync();
        }

        public async Task RegistrateToCourse(int courseId, int studentId)
        {
            var studentCourse = await repository.All<StudentCourse>()
                .FirstOrDefaultAsync(x => x.CourseId == courseId && x.StudentId == studentId);

            if (studentCourse != null)
                throw new ArgumentException(string.Format(Messages.AlreadyExist, "Student-Course"));

            var student = await repository.GetByIdAsync<Student>(studentId);

            if (student is null)
                throw new ArgumentException(string.Format(Messages.DoesntExist, "Student"));

            var course = await repository.GetByIdAsync<Course>(courseId);

            if (course is null)
                throw new ArgumentException(string.Format(Messages.DoesntExist, "Course"));

            if (course.EnrolledStudents + 1 > course.MaxStudents)
                throw new ArgumentException(Messages.CourseIsFull);

            course.EnrolledStudents++;

            var entity = new StudentCourse()
            {
                StudentId = studentId,
                CourseId = courseId,
                Progress = ProgressStatus.Started.ToString(),
                EnrollmentDate = DateTime.Now
            };

            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateStudentCourseStatus(int courseId, int studentId, string progress)
        {
            if (IsValidEnumValue<ProgressStatus>(progress) == false)
                throw new ArgumentException(Messages.WrongProgress);

            var entity = await repository.All<StudentCourse>()
                .FirstOrDefaultAsync(x => x.CourseId == courseId && x.StudentId == studentId);

            if (entity is null)
                throw new ArgumentException(string.Format(Messages.DoesntExist, "Student-Course"));

            entity.Progress = progress;

            await repository.SaveChangesAsync();
        }

        private bool IsValidEnumValue<TEnum>(string value) where TEnum : struct, Enum
        {
            return Enum.TryParse<TEnum>(value, true, out _);
        }
    }
}
