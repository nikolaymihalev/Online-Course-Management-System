using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Infrastructure.Data;

namespace OnlineCourseSystem.UnitTests
{
    internal static class InMemoryDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
