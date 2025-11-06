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

        public UnitOfWork(
            BTPContext ctxt,
            ITreeRepository treeRepo,
            IPlantationSiteRepository plantationSiteRepo,
            IZoneRepository zoneRepo,
            IUserRepository userRepo
            )
        {
            this.ctxt = ctxt;
            this.plantationSiteRepo = plantationSiteRepo;
            this.treeRepo = treeRepo;
            this.zoneRepo = zoneRepo;
            this.userRepo = userRepo;
        }
        
        public IPlantationSiteRepository PlantationSiteRepository => plantationSiteRepo;
        public ITreeRepository TreeRepository => treeRepo;
        public IZoneRepository ZoneRepository => zoneRepo;
        public IUserRepository UserRepository => userRepo;

        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
