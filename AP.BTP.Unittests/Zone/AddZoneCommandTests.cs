using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.CQRS.Zone;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.Zone
{
    [TestClass]
    public class AddZoneCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<IZoneRepository> zoneRepoMock;
        private AddZoneCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            zoneRepoMock = new Mock<IZoneRepository>();

            uowMock.Setup(u => u.ZoneRepository).Returns(zoneRepoMock.Object);

            validator = new AddZoneCommandValidator(uowMock.Object);
        }

        private TreeDTO GetTree()
        {
            return new TreeDTO() { Id = 1, Species = "Oak" };
        }

        private PlantationSiteDTO GetPlantationSite()
        {
            return new PlantationSiteDTO() { Id = 1, City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "" };
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Not_Zero()
        {
            AddZoneCommand command = new AddZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, Tree = GetTree(), PlantationSite = GetPlantationSite() }
            };

            TestValidationResult<AddZoneCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zone.Id).WithErrorMessage("Id should be zero when adding a zone.") != null);
        }
    }
}
