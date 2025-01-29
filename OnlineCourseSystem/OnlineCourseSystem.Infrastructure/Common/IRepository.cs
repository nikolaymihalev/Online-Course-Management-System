namespace OnlineCourseSystem.Infrastructure.Common
{
    /// <summary>
    /// Interface for a repository that defines basic CRUD operations for interacting with a database.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <typeparam name="T">The type of the entity being added.</typeparam>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>A task that completes asynchronously.</returns>
        Task AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <typeparam name="T">The type of the entity to be retrieved.</typeparam>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>A task that returns the entity of type T or null if not found.</returns>
        Task<T?> GetByIdAsync<T>(object id) where T : class;

        /// <summary>
        /// Retrieves all entities of a given type.
        /// </summary>
        /// <typeparam name="T">The type of the entities.</typeparam>
        /// <returns>A collection of entities of type T.</returns>
        IQueryable<T> All<T>() where T : class;

        /// <summary>
        /// Retrieves all entities of a given type for reading (cannot be modified).
        /// </summary>
        /// <typeparam name="T">The type of the entities.</typeparam>
        /// <returns>A collection of entities of type T that are read-only.</returns>
        IQueryable<T> AllReadonly<T>() where T : class;

        /// <summary>
        /// Deletes an entity by its unique identifier.
        /// </summary>
        /// <typeparam name="T">The type of the entity to be deleted.</typeparam>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>A task that completes asynchronously.</returns>
        Task DeleteAsync<T>(object id) where T : class;

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <typeparam name="T">The type of the entity to be deleted.</typeparam>
        /// <param name="entity">The entity to be deleted.</param>
        void Delete<T>(T entity) where T : class;

        /// <summary>
        /// Saves all changes made to the entities in the context.
        /// </summary>
        /// <returns>A task that returns the number of rows affected by the save operation.</returns>
        Task<int> SaveChangesAsync();
    }
}
