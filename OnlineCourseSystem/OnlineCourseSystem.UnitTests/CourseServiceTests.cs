using OnlineCourseSystem.Core.Contracts;
using OnlineCourseSystem.Core.Models.Course;
using OnlineCourseSystem.Core.Services;
using OnlineCourseSystem.Infrastructure.Common;
using OnlineCourseSystem.Infrastructure.Data;

namespace OnlineCourseSystem.UnitTests
{
    public class CourseServiceTests
    {
        private ApplicationDbContext context;
        private Repository repository;
        private ICourseService courseService;

        [SetUp]
        public void Setup()
        {
            context = InMemoryDbContextFactory.Create();
            repository = new Repository(context);
            courseService = new CourseService(repository);
        }

        [TearDown]
        public void Teardown()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task AddCourse_ShouldAddCourseSuccessfully()
        {
            var model = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 20
            };

            int expectedCount = 1;

            await courseService.AddAsync(model);

            var courses = await courseService.GetCoursesAsync();

            Assert.That(expectedCount == courses.Count());
        }

        [Test]
        public async Task GetCourses_ShouldReturnEmptyList()
        {
            int expectedCount = 0;
            var courses = await courseService.GetCoursesAsync();

            Assert.That(courses.Count() == expectedCount);
        }

        [Test]
        public void Delete_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await courseService.DeleteAsync(999));
        }

        [Test]
        public async Task Delete_ShouldDeleteSuccessfully()
        {
            var model = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 20
            };

            await courseService.AddAsync(model);

            int prevCount = 1;
            var courses = await courseService.GetCoursesAsync();
            int actualCount = courses.Count();

            await courseService.DeleteAsync(1);

            int expectedCount = 0;
            courses = await courseService.GetCoursesAsync();

            Assert.That(courses.Count() == expectedCount);
            Assert.That(prevCount == actualCount);
        }

        [Test]
        public void Edit_ShouldThrowException()
        {
            var model = new CourseFormModel()
            {
                Id = 999
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await courseService.EditAsync(model));
        }

        [Test]
        public async Task Edit_ShouldEditSuccessfully()
        {
            var model = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 20
            };

            await courseService.AddAsync(model);

            var newModel = new CourseFormModel()
            {
                Id = 1,
                Name = "Test2",
                Description = "Test Description2",
                MaxStudents = 30
            };

            await courseService.EditAsync(newModel);

            var entity = await courseService.GetByIdAsync(1);

            Assert.That("Test2" == entity.Name);
            Assert.That("Test Description2" == entity.Description);
            Assert.That(30 == entity.MaxStudents);
        }

        [Test]
        public void GetById_ShouldThrowException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await courseService.GetByIdAsync(999));
        }

        [Test]
        public async Task GetById_ShouldReturnCourse()
        {
            var model = new CourseFormModel()
            {
                Name = "Test",
                Description = "Test Description",
                MaxStudents = 20
            };

            await courseService.AddAsync(model);

            var entity = await courseService.GetByIdAsync(1);

            Assert.That(model.Name == entity.Name);
            Assert.That(model.Description == entity.Description);
            Assert.That(model.MaxStudents == entity.MaxStudents);
        }
    }
}
