using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Context;

namespace AP.BTP.Infrastructure.UOW
{
    /// <summary>
    /// Implements the <see cref="IUnitOfWork"/> interface to provide a single point of access
    /// for all repositories and to manage committing changes to the database.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BtpContext ctxt;
        private readonly ITreeRepository treeRepo;
        private readonly IPlantationSiteRepository plantationSiteRepo;
        private readonly IZoneRepository zoneRepo;
        private readonly IUserRepository userRepo;
        private readonly ITaskListRepository taskListRepo;
        private readonly ITaskItemRepository taskItemRepo;
        private readonly ITreePictureRepository treePictureRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class with all required repositories and the database context.
        /// </summary>
        /// <param name="ctxt">The database context.</param>
        /// <param name="treeRepo">Repository for tree entities.</param>
        /// <param name="plantationSiteRepo">Repository for plantation site entities.</param>
        /// <param name="zoneRepo">Repository for zone entities.</param>
        /// <param name="userRepo">Repository for user entities.</param>
        /// <param name="taskListRepo">Repository for task list entities.</param>
        /// <param name="taskItemRepo">Repository for task item entities.</param>
        /// <param name="treePictureRepo">Repository for task item entities.</param>
        public UnitOfWork(
            BtpContext ctxt,
            ITreeRepository treeRepo,
            IPlantationSiteRepository plantationSiteRepo,
            IZoneRepository zoneRepo,
            IUserRepository userRepo,
            ITaskListRepository taskListRepo,
            ITaskItemRepository taskItemRepo,
            ITreePictureRepository treePictureRepo
        ) {
            this.ctxt = ctxt;
            this.plantationSiteRepo = plantationSiteRepo;
            this.treeRepo = treeRepo;
            this.zoneRepo = zoneRepo;
            this.userRepo = userRepo;
            this.taskListRepo = taskListRepo;
            this.taskItemRepo = taskItemRepo;
            this.treePictureRepo = treePictureRepo;
        }

        /// <summary>
        /// Gets the repository for <see cref="PlantationSite"/> entities.
        /// </summary>
        public IPlantationSiteRepository PlantationSiteRepository => plantationSiteRepo;

        /// <summary>
        /// Gets the repository for <see cref="Tree"/> entities.
        /// </summary>
        public ITreeRepository TreeRepository => treeRepo;

        /// <summary>
        /// Gets the repository for <see cref="Zone"/> entities.
        /// </summary>
        public IZoneRepository ZoneRepository => zoneRepo;

        /// <summary>
        /// Gets the repository for <see cref="User"/> entities.
        /// </summary>
        public IUserRepository UserRepository => userRepo;

        /// <summary>
        /// Gets the repository for <see cref="TaskList"/> entities.
        /// </summary>
        public ITaskListRepository TaskListRepository => taskListRepo;

        /// <summary>
        /// Gets the repository for <see cref="TaskItem"/> entities.
        /// </summary>
        public ITaskItemRepository TaskItemRepository => taskItemRepo;

        /// <summary>
        /// Gets the repository for <see cref="TreePicture"/> entities.
        /// </summary>
        public ITreePictureRepository TreePictureRepository => treePictureRepo;

        /// <summary>
        /// Persists all changes made in the repositories to the database asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous save operation.</returns>
        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
