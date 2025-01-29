namespace OnlineCourseSystem.Core.Models.Student
{
    /// <summary>
    /// Model for student course mapping
    /// </summary>
    public class StudentCourseModel
    {
        /// <summary>
        /// Unique identifier for the course
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Unique identifier for the student
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Student progress in the course
        /// </summary>
        public string Progress { get; set; } = string.Empty;

        /// <summary>
        /// Enrollment date of the student
        /// </summary>
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    }
}
