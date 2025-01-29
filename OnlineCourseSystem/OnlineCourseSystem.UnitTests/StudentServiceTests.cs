using OnlineCourseSystem.Core.Contracts;
using OnlineCourseSystem.Core.Models.Student;
using OnlineCourseSystem.Core.Services;
using OnlineCourseSystem.Infrastructure.Common;
using OnlineCourseSystem.Infrastructure.Data;

namespace OnlineCourseSystem.UnitTests
{
    public class StudentServiceTests
    {
        private ApplicationDbContext context;
        private Repository repository;
        private IStudentService studentService;

        [SetUp]
        public void Setup()
        {
            context = InMemoryDbContextFactory.Create();
            repository = new Repository(context);
            studentService = new StudentService(repository);
        }

        [TearDown]
        public void Teardown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task Add_ShouldAddStudent()
        {
            var model = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            await studentService.AddAsync(model);

            int expectedCount = 1;

            var students = await studentService.GetAllStudentsAsync();

            Assert.That(expectedCount == students.Count());
        }

        [Test]
        public async Task GetStudents_ShouldReturnEmptyList()
        {
            int expectedCount = 0;
            var students = await studentService.GetAllStudentsAsync();

            Assert.That(students.Count() == expectedCount);
        }

        [Test]
        public void Delete_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await studentService.DeleteAsync(999));
        }

        [Test]
        public async Task Delete_ShouldDeleteSuccessfully()
        {
            var model = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            await studentService.AddAsync(model);

            int prevCount = 1;
            var students = await studentService.GetAllStudentsAsync();
            int actualCount = students.Count();

            await studentService.DeleteAsync(1);

            int expectedCount = 0;
            students = await studentService.GetAllStudentsAsync();

            Assert.That(students.Count() == expectedCount);
            Assert.That(prevCount == actualCount);
        }

        [Test]
        public void Edit_ShouldThrowException()
        {
            var model = new StudentFormModel()
            {
                Id = 999
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await studentService.EditAsync(model));
        }

        [Test]
        public async Task Edit_ShouldEditSuccessfully()
        {
            var model = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            await studentService.AddAsync(model);

            var newStudent = new StudentFormModel()
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "ivanivanov@gmail.com"
            };

            await studentService.EditAsync(newStudent);

            var entity = await studentService.GetByIdAsync(1);

            Assert.That("Ivan" == entity.FirstName);
            Assert.That("Ivanov" == entity.LastName);
            Assert.That("ivanivanov@gmail.com" == entity.Email);
        }

        [Test]
        public void GetById_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await studentService.GetByIdAsync(999));
        }

        [Test]
        public async Task GetById_ShouldReturnCourse()
        {
            var model = new StudentFormModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com"
            };

            await studentService.AddAsync(model);

            var entity = await studentService.GetByIdAsync(1);

            Assert.That(model.FirstName == entity.FirstName);
            Assert.That(model.LastName == entity.LastName);
            Assert.That(model.Email == entity.Email);
        }
    }
}
