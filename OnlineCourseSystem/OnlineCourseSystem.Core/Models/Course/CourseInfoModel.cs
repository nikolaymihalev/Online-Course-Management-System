namespace OnlineCourseSystem.Core.Models.Course
{
    /// <summary>
    /// Model for course information
    /// </summary>
    public class CourseInfoModel
    {
        /// <summary>
        /// Unique identifier for the course
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the course
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description of the course
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Maximum number of students per course
        /// </summary>
        public int MaxStudents { get; set; }

        /// <summary>
        /// Enrolled students in the course
        /// </summary>
        public int EnrolledStudents { get; set; }

        /// <summary>
        /// Availability of the course
        /// </summary>
        public bool IsAvailable => this.EnrolledStudents < this.MaxStudents;
    }
}
