using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCourseSystem.Infrastructure.Models;

namespace OnlineCourseSystem.Infrastructure.Data.Configurations
{
    internal class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            var seed = new Seed();

            builder.HasKey(k => new { k.CourseId, k.StudentId });

            builder.HasOne(c => c.Course).WithMany(x => x.StudentCourses).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Student).WithMany(x => x.StudentCourses).OnDelete(DeleteBehavior.Restrict);

            builder.HasData(seed.StudentCourse);
        }
    }
}
