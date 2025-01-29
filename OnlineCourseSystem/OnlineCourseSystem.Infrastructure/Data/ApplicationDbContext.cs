using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Infrastructure.Data.Configurations;
using OnlineCourseSystem.Infrastructure.Models;

namespace OnlineCourseSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Student>(new StudentConfiguration());
            modelBuilder.ApplyConfiguration<Course>(new CourseConfiguration());
            modelBuilder.ApplyConfiguration<StudentCourse>(new StudentCourseConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
