using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourseSystem.Infrastructure.Models
{
    /// <summary>
    /// Represents the Student
    /// </summary>
    [Comment("Represents the Student entity")]
    public class Student
    {
        /// <summary>
        /// Unique identifier for the student
        /// </summary>
        [Key]
        [Comment("Student's identifier")]
        public int Id { get; set; }

        /// <summary>
        /// First name of the student
        /// </summary>
        [Required]
        [MaxLength(EntityPropertiesConstants.StudentNameMaxLength)]
        [Comment("Student's first name")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the student
        /// </summary>
        [Required]
        [MaxLength(EntityPropertiesConstants.StudentNameMaxLength)]
        [Comment("Student's last name")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Email of the student
        /// </summary>
        [Required]
        [Comment("Student's email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Collection of student courses
        /// </summary>
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
