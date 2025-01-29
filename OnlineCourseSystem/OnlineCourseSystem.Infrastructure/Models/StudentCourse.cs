using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourseSystem.Infrastructure.Models
{
    /// <summary>
    /// Represents the Student-Course mapping
    /// </summary>
    [Comment("Represents the Student Course mapping entity")]
    public class StudentCourse
    {
        /// <summary>
        /// Unique identifier for the course
        /// </summary>
        [Required]
        [Comment("Course's identifier")]
        public int CourseId { get; set; }

        /// <summary>
        /// Unique identifier for the student
        /// </summary>
        [Required]
        [Comment("Student's identifier")]
        public int StudentId { get; set; }

        /// <summary>
        /// Student progress in the course
        /// </summary>
        [Required]
        [Comment("Student progress")]
        public string Progress { get; set; } = string.Empty;

        /// <summary>
        /// Enrollment date of the student
        /// </summary>
        [Required]
        [Comment("Student enrollment date")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Course entity 
        /// </summary>
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = null!;

        /// <summary>
        /// Student entity
        /// </summary>
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;
    }
}
