using OnlineCourseSystem.Infrastructure.Models;

namespace OnlineCourseSystem.Infrastructure.Data
{
    internal class Seed
    {
        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
        public StudentCourse StudentCourse { get; set; } = null!;

        public Seed() 
        {
            SeedCourse();
            SeedStudent();
            SeedStudentCourse();
        }

        private void SeedCourse()
        {
            Course = new Course()
            {
                Id = 1,
                Name = "C# Fundamentals",
                Description = "A course that teaches the fundamentals of C# programming.",
                MaxStudents = 50
            };
        }

        private void SeedStudent()
        {
            Student = new Student()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            };
        }

        private void SeedStudentCourse()
        {
            StudentCourse = new StudentCourse()
            {
                CourseId = 1,
                StudentId = 1,
                Progress = "Started",
                EnrollmentDate = new DateTime(2025, 1, 29)
            };

            this.Course.EnrolledStudents++;
        }
    }
}
