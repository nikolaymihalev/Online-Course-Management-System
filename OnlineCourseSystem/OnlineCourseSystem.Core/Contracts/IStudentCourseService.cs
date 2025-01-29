using OnlineCourseSystem.Core.Models.Student;

namespace OnlineCourseSystem.Core.Contracts
{
    /// <summary>
    /// Service interface for managing student course enrollments.
    /// </summary>
    public interface IStudentCourseService
    {
        /// <summary>
        /// Registers a student for a course.
        /// </summary>
        /// <param name="courseId">The unique identifier of the course.</param>
        /// <param name="studentId">The unique identifier of the student.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task RegistrateToCourse(int courseId, int studentId);

        /// <summary>
        /// Removes a student from a course.
        /// </summary>
        /// <param name="courseId">The unique identifier of the course.</param>
        /// <param name="studentId">The unique identifier of the student.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task LeaveCourse(int courseId, int studentId);

        /// <summary>
        /// Retrieves a list of courses a student is enrolled in.
        /// </summary>
        /// <param name="studentId">The unique identifier of the student.</param>
        /// <returns>A task that returns a collection of student course models.</returns>
        Task<IEnumerable<StudentCourseModel>> GetStudentsCourses(int studentId);

        /// <summary>
        /// Updates the progress status of a student in a specific course.
        /// </summary>
        /// <param name="courseId">The unique identifier of the course.</param>
        /// <param name="studentId">The unique identifier of the student.</param>
        /// <param name="progress">The new progress status.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateStudentCourseStatus(int courseId, int studentId, string progress);
    }

}
