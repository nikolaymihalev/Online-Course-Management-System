using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCourseSystem.Infrastructure.Models;

namespace OnlineCourseSystem.Infrastructure.Data.Configurations
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            var seed = new Seed();

            builder.HasData(seed.Student);
        }
    }
}
