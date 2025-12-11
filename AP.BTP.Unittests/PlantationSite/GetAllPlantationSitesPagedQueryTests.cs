using AP.BTP.Application.Interfaces;
using Moq;

namespace AP.BTP.Unittests.PlantationSite
{
    [TestClass]
    public class GetAllPlantationSitesPagedQueryTests
    {
        private Mock<IUnitOfWork> uowMock = null!;
        private Mock<IPlantationSiteRepository> plantationSiteRepoMock = null!;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            plantationSiteRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationSiteRepoMock.Object);
        }
    }
}