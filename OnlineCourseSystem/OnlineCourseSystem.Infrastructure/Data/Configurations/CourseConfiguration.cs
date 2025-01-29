using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCourseSystem.Infrastructure.Models;

namespace OnlineCourseSystem.Infrastructure.Data.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            var seed = new Seed();

            builder.HasData(seed.Course);
        }
    }
}
