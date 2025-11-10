using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Context;

namespace AP.BTP.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BTPContext ctxt;
        private readonly ITreeRepository treeRepo;
        private readonly IPlantationSiteRepository plantationSiteRepo;
        private readonly IZoneRepository zoneRepo;
        private readonly IUserRepository userRepo;
        private readonly ITaskListRepository taskListRepo;
        private readonly ITaskItemRepository taskItemRepo;

        public UnitOfWork(
            BTPContext ctxt,
            ITreeRepository treeRepo,
            IPlantationSiteRepository plantationSiteRepo,
            IZoneRepository zoneRepo,
            IUserRepository userRepo,
            ITaskListRepository taskListRepo,
            ITaskItemRepository taskItemRepo
            )
        {
            this.ctxt = ctxt;
            this.plantationSiteRepo = plantationSiteRepo;
            this.treeRepo = treeRepo;
            this.zoneRepo = zoneRepo;
            this.userRepo = userRepo;
            this.taskListRepo = taskListRepo;
            this.taskItemRepo = taskItemRepo;
        }
        
        public IPlantationSiteRepository PlantationSiteRepository => plantationSiteRepo;
        public ITreeRepository TreeRepository => treeRepo;
        public IZoneRepository ZoneRepository => zoneRepo;
        public IUserRepository UserRepository => userRepo;
        public ITaskListRepository TaskListRepository => taskListRepo;
        public ITaskItemRepository TaskItemRepository => taskItemRepo;

        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
