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

        private TreeDTO Tree 
        {
            get
            {
                return new TreeDTO() { Id = 1, Species = "Oak" };
            }
        }

        private PlantationSiteDTO PlantationSite { 
            get
            {
                return new PlantationSiteDTO() { Id = 1, City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "" };
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
                    Id = PlantationSite.Id,
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
                Zone = new ZoneDTO() { Id = 0, Name = "Zone", Size = 5, TreeId = Tree.Id, PlantationSiteId = PlantationSite.Id }
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
                    Id = PlantationSite.Id,
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
                Zone = new ZoneDTO() { Id = 1, TreeId = Tree.Id, PlantationSiteId = 0 }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

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
                    Id = PlantationSite.Id,
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
                Zone = new ZoneDTO() { Id = 1, TreeId = 0, PlantationSiteId = PlantationSite.Id }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zone.TreeId).WithErrorMessage("The tree must already exist.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_With_Duplicate_Zone_Name_If_Id_Is_Unique()
        {
            PlantationSiteDTO plantationSite = PlantationSite;
            List<Domain.Zone> zones = new List<Domain.Zone>();

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.PlantationSite()
                {
                    Id = plantationSite.Id,
                    Zones = zones,
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                });


            UpdateZoneCommand command = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, Name = "Zone1", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

            zones.Add(new Domain.Zone() 
                {
                    Id = 1,
                    Name = "Zone1",
                    Tree = new Domain.Tree() { Id = 1,
                    Species = "Oak"
                },
                PlantationSite = new Domain.PlantationSite()
                {
                    Id = plantationSite.Id,
                    Zones = zones,
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                }
            });

            UpdateZoneCommand command2 = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 2, Name = "Zone1", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id }
            };

            TestValidationResult<UpdateZoneCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            Assert.IsTrue(result2.ShouldHaveValidationErrorFor(command => command.Zone).WithErrorMessage("The zone name must be unique within a plantationsite") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_With_Duplicate_Zone_Name_If_Id_Matches()
        {
            PlantationSiteDTO plantationSite = PlantationSite;
            List<Domain.Zone> zones = new List<Domain.Zone>();

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.PlantationSite()
                {
                    Id = plantationSite.Id,
                    Zones = zones,
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                });


            UpdateZoneCommand command = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, Name = "Zone1", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

            zones.Add(new Domain.Zone() 
                {
                    Id = 1,
                    Name = "Zone1",
                    Tree = new Domain.Tree() { Id = 1,
                    Species = "Oak"
                },
                PlantationSite = new Domain.PlantationSite()
                {
                    Id = plantationSite.Id,
                    Zones = zones,
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                }
            });

            UpdateZoneCommand command2 = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, Name = "Zone1", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id }
            };

            TestValidationResult<UpdateZoneCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            result2.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_Without_Duplicate_Zone_Name()
        {
            PlantationSiteDTO plantationSite = PlantationSite;
            List<Domain.Zone> zones = new List<Domain.Zone>();

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.PlantationSite()
                {
                    Id = plantationSite.Id,
                    Zones = zones,
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                });


            UpdateZoneCommand command = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 1, Name = "Zone1", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id }
            };

            TestValidationResult<UpdateZoneCommand> result = await validator.TestValidateAsync(command);

            zones.Add(new Domain.Zone() 
                {
                    Id = 1,
                    Name = "Zone1",
                    Tree = new Domain.Tree() { Id = 1,
                    Species = "Oak"
                },
                PlantationSite = new Domain.PlantationSite()
                {
                    Id = plantationSite.Id,
                    Zones = zones,
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                }
            });

            UpdateZoneCommand command2 = new UpdateZoneCommand
            {
                Zone = new ZoneDTO() { Id = 2, Name = "Zone2", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id }
            };

            TestValidationResult<UpdateZoneCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            result2.ShouldNotHaveAnyValidationErrors();
        }
    }
}
