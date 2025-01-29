namespace OnlineCourseSystem.Core.Models.Student
{
    /// <summary>
    /// Model for student information
    /// </summary>
    public class StudentInfoModel
    {
        /// <summary>
        /// Unique identifier for the student
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of the student
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the student
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Full name of the student
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Email of the student
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}
