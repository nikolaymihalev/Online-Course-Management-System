using OnlineCourseSystem.Core.Constants;
using OnlineCourseSystem.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace OnlineCourseSystem.Core.Models.Student
{
    /// <summary>
    /// Model for adding or editing student
    /// </summary>
    public class StudentFormModel
    {
        /// <summary>
        /// Unique identifier for the student
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of the student
        /// </summary>
        [Required(ErrorMessage = Messages.Required)]
        [StringLength(EntityPropertiesConstants.StudentNameMaxLength,
            MinimumLength = EntityPropertiesConstants.StudentNameMinLength,
            ErrorMessage = Messages.StringLength)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the student
        /// </summary>
        [Required(ErrorMessage = Messages.Required)]
        [StringLength(EntityPropertiesConstants.StudentNameMaxLength,
            MinimumLength = EntityPropertiesConstants.StudentNameMinLength,
            ErrorMessage = Messages.StringLength)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Email of the student
        /// </summary>
        [Required(ErrorMessage = Messages.Required)]
        [EmailAddress(ErrorMessage = Messages.EmailAddress)]
        public string Email { get; set; } = string.Empty;
    }
}
