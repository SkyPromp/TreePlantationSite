using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.CQRS.Zone;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.Zone
{
    [TestClass]
    public class AddZonesManyCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<IZoneRepository> zoneRepoMock;
        private AddZonesManyCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            zoneRepoMock = new Mock<IZoneRepository>();

            uowMock.Setup(u => u.ZoneRepository).Returns(zoneRepoMock.Object);

            validator = new AddZonesManyCommandValidator(uowMock.Object);
        }

        private TreeDTO Tree
        {
            get
            {
                return new TreeDTO() { Id = 1, Species = "Oak" };
            }
        }

        private PlantationSiteDTO PlantationSite
        {
            get
            {
                return new PlantationSiteDTO() { Id = 1, City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "" };
            }
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Not_Zero()
        {
            List<ZoneDTO> Zones = new List<ZoneDTO>();
            for(int i = 1; i < 4; i++)
            {
                ZoneDTO zone = new ZoneDTO() { Id=1, PlantationSiteId=PlantationSite.Id, TreeId=Tree.Id};
                Zones.Add(zone);
            }

            AddZonesManyCommand command = new AddZonesManyCommand
            {
                Zones = Zones
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zones.All(zone => zone.Id == 0)).WithErrorMessage("All id's should be zero when adding a zone.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_PlantationSiteId_Zero()
        {
            List<ZoneDTO> Zones = new List<ZoneDTO>();

            for(int i = 1; i < 4; i++)
            {
                ZoneDTO zone = new ZoneDTO() { Id=1, PlantationSiteId=0, TreeId=Tree.Id};
                Zones.Add(zone);
            }

            AddZonesManyCommand command = new AddZonesManyCommand
            {
                Zones = Zones
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zones.All(zone => zone.PlantationSiteId != 0)).WithErrorMessage("All plantation sites must already exist.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TreeId_Zero()
        {
            List<ZoneDTO> Zones = new List<ZoneDTO>();

            for(int i = 1; i < 4; i++)
            {
                ZoneDTO zone = new ZoneDTO() { Id=1, PlantationSiteId=PlantationSite.Id, TreeId=0};
                Zones.Add(zone);
            }

            AddZonesManyCommand command = new AddZonesManyCommand
            {
                Zones = Zones
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zones.All(zone => zone.TreeId != 0)).WithErrorMessage("All trees must already exist.") != null);
        }
    }
}
