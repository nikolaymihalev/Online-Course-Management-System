using OnlineCourseSystem.Core.Models.Student;

namespace OnlineCourseSystem.Core.Contracts
{
    /// <summary>
    /// Service interface for managing students.
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Retrieves a list of all students in the system.
        /// </summary>
        /// <returns>A task that returns a collection of student information models.</returns>
        Task<IEnumerable<StudentInfoModel>> AllStudentsAsync();

        /// <summary>
        /// Adds a new student to the system.
        /// </summary>
        /// <param name="model">The student data model containing necessary information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddAsync(StudentFormModel model);

        /// <summary>
        /// Edits an existing student's information.
        /// </summary>
        /// <param name="model">The updated student data model.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task EditAsync(StudentFormModel model);

        /// <summary>
        /// Retrieves a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student.</param>
        /// <returns>A task that returns the student information model.</returns>
        Task<StudentInfoModel> GetByIdAsync(int id);

        /// <summary>
        /// Deletes a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(int id);
    }

}
