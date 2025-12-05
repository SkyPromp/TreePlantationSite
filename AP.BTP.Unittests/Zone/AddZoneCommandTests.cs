
using AP.BTP.Application.CQRS.Zone;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
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

        private TreeDTO TreeDTO 
        {
            get
            {
                return new TreeDTO() { Id = 1, Species = "Oak" };
            }
        }

        private Domain.Tree Tree
        {
            get
            {
                return new Domain.Tree() { Id = 1, Species = "Oak" };
            }
        }

        private PlantationSiteDTO PlantationSiteDTO { 
            get
            {
                return new PlantationSiteDTO() { Id = 1, City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "", Zones=new List<ZoneDTO>(), Size=100 };
            }
        }

        private Domain.PlantationSite PlantationSite { 
            get
            {
                return new Domain.PlantationSite() { Id = 1, City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "", Zones=new List<Domain.Zone>(), Size=100 };
            }
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Not_Zero()
        {
            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.PlantationSite()
                {
                    Id = PlantationSiteDTO.Id,
                    Zones = new List<Domain.Zone>(),
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                });

            AddZoneCommand command = new AddZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, Name = "Zone", Size = 5, TreeId = TreeDTO.Id, PlantationSiteId = PlantationSiteDTO.Id }
            };

            TestValidationResult<AddZoneCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zone.Id).WithErrorMessage("Id should be zero when adding a zone.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_PlantationId_Zero()
        {
            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.PlantationSite()
                {
                    Id = PlantationSiteDTO.Id,
                    Zones = new List<Domain.Zone>(),
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                });

            AddZoneCommand command = new AddZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, TreeId = TreeDTO.Id, PlantationSiteId = 0 }
            };

            TestValidationResult<AddZoneCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zone.PlantationSiteId).WithErrorMessage("The plantation site must already exist.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TreeId_Zero()
        {
            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.PlantationSite()
                {
                    Id = PlantationSiteDTO.Id,
                    Zones = new List<Domain.Zone>(),
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                });

            AddZoneCommand command = new AddZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, TreeId = 0, PlantationSiteId = PlantationSiteDTO.Id }
            };

            TestValidationResult<AddZoneCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zone.TreeId).WithErrorMessage("The tree must already exist.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_With_Duplicate_Zone_Name()
        {
            PlantationSiteDTO plantationSiteDTO = PlantationSiteDTO;
            Domain.PlantationSite plantationSite = PlantationSite;

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(plantationSite);


            AddZoneCommand command = new AddZoneCommand
            {
                Zone = new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size=30 }
            };

            TestValidationResult<AddZoneCommand> result = await validator.TestValidateAsync(command);

            plantationSite.Zones.Add(new Domain.Zone() {
                Id = 1,
                Name = "Zone1",
                Tree = new Domain.Tree() { Id = 1, Species = "Oak" },
                Size=30,
                PlantationSite = PlantationSite
            });

            AddZoneCommand command2 = new AddZoneCommand
            {
                Zone = new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size=30 }
            };

            TestValidationResult<AddZoneCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            Assert.IsTrue(result2.ShouldHaveValidationErrorFor(command => command.Zone).WithErrorMessage("The zone name must be unique within a plantationsite.") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_Without_Duplicate_Zone_Name()
        {
            PlantationSiteDTO plantationSiteDTO = PlantationSiteDTO;
            Domain.PlantationSite plantationSite = PlantationSite;

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(plantationSite);


            AddZoneCommand command = new AddZoneCommand
            {
                Zone = new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 30 }
            };

            TestValidationResult<AddZoneCommand> result = await validator.TestValidateAsync(command);

            plantationSite.Zones.Add(new Domain.Zone() 
            {
                Id = 1,
                Name = "Zone1",
                Tree = Tree,
                Size=30,
                PlantationSite = plantationSite
            });

            AddZoneCommand command2 = new AddZoneCommand
            {
                Zone = new ZoneDTO() { Id = 0, Name = "Zone2", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size=30 }
            };

            TestValidationResult<AddZoneCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            result2.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Total_Zone_Size_Is_Smaller_Than_The_PlantationSite_Size()
        {
            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            Domain.PlantationSite plantationSite = PlantationSite;
            plantationSite.Size = 100;

            plantationSite.Zones.Add(
                new Domain.Zone()
                {
                    Id = 1,
                    Name = "Zone",
                    Size = 40,
                    TreeId = TreeDTO.Id,
                    PlantationSiteId = PlantationSiteDTO.Id,
                    PlantationSite = plantationSite,
                    Tree = Tree
                }
            );

            plantationSite.Zones.Add(
                new Domain.Zone()
                {
                    Id = 2,
                    Name = "Zone 2",
                    Size = 40,
                    TreeId = TreeDTO.Id,
                    PlantationSiteId = PlantationSiteDTO.Id,
                    PlantationSite = plantationSite,
                    Tree = Tree
                }
            );

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(plantationSite);

            AddZoneCommand command = new AddZoneCommand
            {
                Zone = new ZoneDTO() { Id = 0, Name = "Zone3", Size = 20, TreeId = TreeDTO.Id, PlantationSiteId = PlantationSiteDTO.Id }
            };

            TestValidationResult<AddZoneCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveValidationErrorFor(command => command.Zone);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Total_Zone_Size_Is_Bigger_Than_The_PlantationSite_Size()
        {
            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            Domain.PlantationSite plantationSite = PlantationSite;
            plantationSite.Size = 100;

            plantationSite.Zones.Add(
                new Domain.Zone()
                {
                    Id = 1,
                    Name = "Zone",
                    Size = 40,
                    TreeId = TreeDTO.Id,
                    PlantationSiteId = PlantationSiteDTO.Id,
                    PlantationSite = plantationSite,
                    Tree = Tree
                }
            );

            plantationSite.Zones.Add(
                new Domain.Zone()
                {
                    Id = 2,
                    Name = "Zone 2",
                    Size = 40,
                    TreeId = TreeDTO.Id,
                    PlantationSiteId = PlantationSiteDTO.Id,
                    PlantationSite = plantationSite,
                    Tree = Tree
                }
            );

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(plantationSite);

            AddZoneCommand command = new AddZoneCommand
            {
                Zone = new ZoneDTO() { Id = 0, Name = "Zone3", Size = 110, TreeId = TreeDTO.Id, PlantationSiteId = PlantationSiteDTO.Id }
            };

            TestValidationResult<AddZoneCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zone).WithErrorMessage("The sum of all the zone sizes must be smaller than the total plantationsite area.") != null);
        }
    }
}
