using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Context;

namespace AP.BTP.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BTPContext ctxt;
        private readonly ITreeRepository treeRepo;
        private readonly IPlantationSiteRepository plantationSiteRepo;

        public UnitOfWork(
            BTPContext ctxt,
            IPlantationSiteRepository plantationSiteRepo,
            ITreeRepository treeRepo
            )
        {
            this.ctxt = ctxt;
            this.plantationSiteRepo = plantationSiteRepo;
            this.treeRepo = treeRepo;
        }
        
        public IPlantationSiteRepository PlantationSiteRepository => plantationSiteRepo;
        public ITreeRepository TreeRepository => treeRepo;

        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
