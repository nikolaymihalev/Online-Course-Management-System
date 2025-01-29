using OnlineCourseSystem.Core.Contracts;
using OnlineCourseSystem.Core.Enums;
using OnlineCourseSystem.Core.Models.Course;
using OnlineCourseSystem.Core.Models.Student;
using OnlineCourseSystem.Core.Services;
using OnlineCourseSystem.Infrastructure.Common;
using OnlineCourseSystem.Infrastructure.Data;

namespace OnlineCourseSystem.UnitTests
{
    public class StudentCourseServiceTests
    {
        private ApplicationDbContext context;
        private Repository repository;
        private IStudentCourseService studentCourseService;
        private ICourseService courseService;
        private IStudentService studentService;

        [SetUp]
        public void Setup()
        {
            context = InMemoryDbContextFactory.Create();
            repository = new Repository(context);
            studentCourseService = new StudentCourseService(repository);
            courseService = new CourseService(repository);
            studentService = new StudentService(repository);
        }

        [TearDown]
        public void Teardown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task GetStudentsCourses_ShouldReturnList()
        {
            var course = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 20
            };

            var student = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            await courseService.AddAsync(course);
            await studentService.AddAsync(student);
            await studentCourseService.RegistrateToCourse(1, 1);

            int expectedCount = 1;

            var studentCourses = await studentCourseService.GetStudentsCourses(1);

            Assert.That(expectedCount == studentCourses.Count());
        }

        [Test]
        public async Task GetStudentsCourses_ShouldReturnEmptyList()
        {
            int expectedCount = 0;

            var studentCourses = await studentCourseService.GetStudentsCourses(1);

            Assert.That(expectedCount == studentCourses.Count());
        }

        [Test]
        public void Leave_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await studentCourseService.LeaveCourse(999, 999));
        }

        [Test]
        public async Task Leave_ShouldLeaveSuccessfully()
        {
            var course = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 20
            };

            var student = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            await courseService.AddAsync(course);
            await studentService.AddAsync(student);
            await studentCourseService.RegistrateToCourse(1, 1);

            int expectedCount = 0;
            int excectedStudents = 0;

            await studentCourseService.LeaveCourse(1, 1);

            var studentCourses = await studentCourseService.GetStudentsCourses(1);

            var courseEn = await courseService.GetByIdAsync(1);

            Assert.That(expectedCount == studentCourses.Count());
            Assert.That(excectedStudents == courseEn.EnrolledStudents);
        }

        [Test]
        public async Task Registrate_ShouldThrowExceptionBecauseItIsExisting()
        {
            var course = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 20
            };

            var student = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            await courseService.AddAsync(course);
            await studentService.AddAsync(student);
            await studentCourseService.RegistrateToCourse(1, 1);

            Assert.ThrowsAsync<ArgumentException>(async () => await studentCourseService.RegistrateToCourse(1, 1));
        }

        [Test]
        public async Task Registrate_ShouldThrowExceptionBecauseCourseDoesntExist()
        {
            var student = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            await studentService.AddAsync(student);

            Assert.ThrowsAsync<ArgumentException>(async () => await studentCourseService.RegistrateToCourse(1, 1));
        }

        [Test]
        public async Task Registrate_ShouldThrowExceptionBecauseStudentDoesntExist()
        {
            var course = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 20
            };

            await courseService.AddAsync(course);

            Assert.ThrowsAsync<ArgumentException>(async () => await studentCourseService.RegistrateToCourse(1, 1));
        }

        [Test]
        public async Task Registrate_ShouldThrowExceptionBecauseMaxStudentsLimit()
        {
            var course = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 1
            };

            var student = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            var student2 = new StudentFormModel()
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivanivanov@gmail.com"
            };

            await courseService.AddAsync(course);
            await studentService.AddAsync(student);
            await studentService.AddAsync(student2);
            await studentCourseService.RegistrateToCourse(1, 1);

            Assert.ThrowsAsync<ArgumentException>(async () => await studentCourseService.RegistrateToCourse(1, 2));
        }

        [Test]
        public async Task Registrate_ShouldRegistrateSuccessfully()
        {
            var course = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 20
            };

            var student = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            await courseService.AddAsync(course);
            await studentService.AddAsync(student);
            await studentCourseService.RegistrateToCourse(1, 1);

            int expectedCount = 1;
            int expectedStudentsInCourse = 1;

            var courseEn = await courseService.GetByIdAsync(1);
            var studentsCourses = await studentCourseService.GetStudentsCourses(1);

            Assert.That(expectedCount == studentsCourses.Count());
            Assert.That(expectedStudentsInCourse == courseEn.EnrolledStudents);
        }

        [Test]
        public void Update_ShouldThrowExceptionBecauseDoesntExist()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await studentCourseService.UpdateStudentCourseStatus(1, 1, ProgressStatus.Completed.ToString()));
        }

        [Test]
        public void Update_ShouldThrowExceptionBecauseOfStatusEnum()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await studentCourseService.UpdateStudentCourseStatus(1, 1, "Invalid"));
        }

        [Test]
        public async Task Update_ShouldUpdateSuccessfully()
        {
            var course = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 20
            };

            var student = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            await courseService.AddAsync(course);
            await studentService.AddAsync(student);
            await studentCourseService.RegistrateToCourse(1, 1);

            await studentCourseService.UpdateStudentCourseStatus(1, 1, ProgressStatus.Halfway.ToString());

            var studentCourses = await studentCourseService.GetStudentsCourses(1);

            var studentCourse = studentCourses.First();

            string expectedProgress = ProgressStatus.Halfway.ToString();

            Assert.That(expectedProgress == studentCourse.Progress);
        }
    }
}
