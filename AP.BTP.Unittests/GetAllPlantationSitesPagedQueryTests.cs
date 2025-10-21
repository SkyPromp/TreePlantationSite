

using AP.BTP.Application.Interfaces;
using Moq;

namespace AP.BTP.Unittests
{
    [TestClass]
    public class GetAllPlantationSitesPagedQueryTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<IPlantationSiteRepository> plantationSiteRepoMock;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            plantationSiteRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationSiteRepoMock.Object);
        }
    }
}