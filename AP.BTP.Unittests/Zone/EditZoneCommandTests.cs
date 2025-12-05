using AP.BTP.Application.CQRS.Zone;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.Zone
{
    [TestClass]
    public class UpdateZoneCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<IZoneRepository> zoneRepoMock;
        private UpdateZoneCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            zoneRepoMock = new Mock<IZoneRepository>();

            uowMock.Setup(u => u.ZoneRepository).Returns(zoneRepoMock.Object);

            validator = new UpdateZoneCommandValidator(uowMock.Object);
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
        public async Task Should_Have_Error_When_Id_Is_Zero()
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

            UpdateZoneCommand command = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 0, Name = "Zone", Size = 5, TreeId = TreeDTO.Id, PlantationSiteId = PlantationSiteDTO.Id }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zone.Id).WithErrorMessage("Id should not be zero when updating a zone.") != null);
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

            UpdateZoneCommand command = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, TreeId = TreeDTO.Id, PlantationSiteId = 0 }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zone.PlantationSiteId).WithErrorMessage("The plantation site must already exist.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TreeId_Zero()
        {
            Domain.PlantationSite plantationSite = PlantationSite;
            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(plantationSite);

            UpdateZoneCommand command = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, TreeId = 0, PlantationSiteId = PlantationSiteDTO.Id, Size = 1 }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zone.TreeId).WithErrorMessage("The tree must already exist.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_With_Duplicate_Zone_Name_If_Id_Is_Unique()
        {
            PlantationSiteDTO plantationSiteDTO = PlantationSiteDTO;
            Domain.PlantationSite plantationSite = PlantationSite;

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(plantationSite);


            UpdateZoneCommand command = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 1 }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

            plantationSite.Zones.Add(new Domain.Zone() 
            {
                Id = 1,
                Name = "Zone1",
                Tree = new Domain.Tree() { Id = 1, Species = "Oak" },
                Size = 1,
                PlantationSite = plantationSite
            });

            UpdateZoneCommand command2 = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 2, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 1 }
            };

            TestValidationResult<UpdateZoneCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            Assert.IsTrue(result2.ShouldHaveValidationErrorFor(command => command.Zone).WithErrorMessage("The zone name must be unique within a plantationsite") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_With_Duplicate_Zone_Name_If_Id_Matches()
        {
            PlantationSiteDTO plantationSiteDTO = PlantationSiteDTO;
            Domain.PlantationSite plantationSite = PlantationSite;

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(plantationSite);


            UpdateZoneCommand command = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 1 }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

            plantationSite.Zones.Add(new Domain.Zone() 
            {
                Id = 1,
                Name = "Zone1",
                Tree = new Domain.Tree() { Id = 1, Species = "Oak" },
                Size = 1,
                PlantationSite = plantationSite
            });

            UpdateZoneCommand command2 = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 1 }
            };

            TestValidationResult<UpdateZoneCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            result2.ShouldNotHaveAnyValidationErrors();
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


            UpdateZoneCommand command = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 1 }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

            plantationSite.Zones.Add(new Domain.Zone() 
            {
                Id = 1,
                Name = "Zone1",
                Tree = new Domain.Tree() { Id = 1, Species = "Oak" },
                Size = 1,
                PlantationSite = plantationSite
            });

            UpdateZoneCommand command2 = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 2, Name = "Zone2", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 1 }
            };

            TestValidationResult<UpdateZoneCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            result2.ShouldNotHaveAnyValidationErrors();
        }
    }
}
