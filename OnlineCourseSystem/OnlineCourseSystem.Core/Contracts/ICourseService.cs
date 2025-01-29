using OnlineCourseSystem.Core.Models.Course;

namespace OnlineCourseSystem.Core.Contracts
{
    /// <summary>
    /// Service interface for managing courses.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Adds a new course to the system.
        /// </summary>
        /// <param name="model">The course data model containing necessary information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(CourseFormModel model);

        /// <summary>
        /// Edits an existing course.
        /// </summary>
        /// <param name="model">The updated course data model.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task EditAsync(CourseFormModel model);

        /// <summary>
        /// Retrieves a course by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the course.</param>
        /// <returns>A task that returns the course information model.</returns>
        Task<CourseInfoModel> GetByIdAsync(int id);

        /// <summary>
        /// Deletes a course by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the course to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Retrieves a list of all available courses.
        /// </summary>
        /// <returns>A task that returns a collection of course information models.</returns>
        Task<IEnumerable<CourseInfoModel>> GetCoursesAsync();
    }

}
