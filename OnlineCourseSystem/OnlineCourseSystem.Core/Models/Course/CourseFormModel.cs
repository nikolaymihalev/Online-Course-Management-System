using OnlineCourseSystem.Core.Constants;
using OnlineCourseSystem.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourseSystem.Core.Models.Course
{
    /// <summary>
    /// Model for adding or editing course
    /// </summary>
    public class CourseFormModel
    {
        /// <summary>
        /// Unique identifier for the course
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the course
        /// </summary>
        [Required(ErrorMessage = Messages.Required)]
        [StringLength(EntityPropertiesConstants.CourseNameMaxLength, 
            MinimumLength = EntityPropertiesConstants.CourseNameMinLength,
            ErrorMessage = Messages.StringLength)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description of the course
        /// </summary>
        [Required(ErrorMessage = Messages.Required)]
        [StringLength(EntityPropertiesConstants.CourseDescriptionMaxLength,
            MinimumLength = EntityPropertiesConstants.CourseDescriptionMinLength,
            ErrorMessage = Messages.StringLength)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Maximum number of students per course
        /// </summary>
        [Required(ErrorMessage = Messages.Required)]
        public int MaxStudents { get; set; }
    }
}
