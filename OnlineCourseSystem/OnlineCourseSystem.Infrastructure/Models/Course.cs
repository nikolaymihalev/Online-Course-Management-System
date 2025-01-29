using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourseSystem.Infrastructure.Models
{
    /// <summary>
    /// Represents the Course
    /// </summary>
    [Comment("Represents the Course entity")]
    public class Course
    {
        /// <summary>
        /// Unique identifier for the course
        /// </summary>
        [Key]
        [Comment("Course's identifier")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the course
        /// </summary>
        [Required]
        [MaxLength(EntityPropertiesConstants.CourseNameMaxLength)]
        [Comment("Course's name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description of the course
        /// </summary>
        [Required]
        [MaxLength(EntityPropertiesConstants.CourseDescriptionMaxLength)]
        [Comment("Course's description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Maximum number of students per course
        /// </summary>
        [Required]
        [Comment("Course's max students")]
        public int MaxStudents { get; set; }

        /// <summary>
        /// Enrolled students in the course
        /// </summary>
        [Comment("Course's enrolled students")]
        public int EnrolledStudents { get; set; }

        /// <summary>
        /// Collection of student courses
        /// </summary>
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
