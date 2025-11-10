namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Defines a unit of work for managing repositories and committing changes to the data store.
    /// Provides a central point for coordinating operations across multiple repositories.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the repository for managing <see cref="Tree"/> entities.
        /// </summary>
        ITreeRepository TreeRepository { get; }

        /// <summary>
        /// Gets the repository for managing <see cref="Zone"/> entities.
        /// </summary>
        IZoneRepository ZoneRepository { get; }

        /// <summary>
        /// Gets the repository for managing <see cref="PlantationSite"/> entities.
        /// </summary>
        IPlantationSiteRepository PlantationSiteRepository { get; }

        /// <summary>
        /// Gets the repository for managing <see cref="User"/> entities.
        /// </summary>
        IUserRepository UserRepository { get; }

        /// <summary>
        /// Gets the repository for managing <see cref="TaskList"/> entities.
        /// </summary>
        ITaskListRepository TaskListRepository { get; }

        /// <summary>
        /// Gets the repository for managing <see cref="TaskItem"/> entities.
        /// </summary>
        ITaskItemRepository TaskItemRepository { get; }

        /// <summary>
        /// Commits all changes made through the repositories to the underlying data store.
        /// </summary>
        /// <returns>A task representing the asynchronous commit operation.</returns>
        Task Commit();
    }

}