using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Context;

namespace AP.BTP.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BTPContext ctxt;
        private readonly IPlantationSiteRepository plantationSiteRepo;

        public UnitOfWork(BTPContext ctxt, IPlantationSiteRepository plantationSiteRepo)
        {
            this.ctxt = ctxt;
            this.plantationSiteRepo = plantationSiteRepo;
        }
        
        public IPlantationSiteRepository PlantationSiteRepository => plantationSiteRepo;

        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
