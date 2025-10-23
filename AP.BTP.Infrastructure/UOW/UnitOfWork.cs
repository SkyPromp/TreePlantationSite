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

        public UnitOfWork(
            BTPContext ctxt,
            ITreeRepository treeRepo,
            IPlantationSiteRepository plantationSiteRepo,
            IZoneRepository zoneRepo
            )
        {
            this.ctxt = ctxt;
            this.plantationSiteRepo = plantationSiteRepo;
            this.treeRepo = treeRepo;
            this.zoneRepo = zoneRepo;
        }
        
        public IPlantationSiteRepository PlantationSiteRepository => plantationSiteRepo;
        public ITreeRepository TreeRepository => treeRepo;
        public IZoneRepository ZoneRepository => zoneRepo;

        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
