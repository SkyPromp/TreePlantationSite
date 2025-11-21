using AP.BTP.Application.CQRS.Zone;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
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
            List<ZoneDTO> zonesDTO = new List<ZoneDTO>();
            List<Domain.Zone> zones = new List<Domain.Zone>();

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.PlantationSite()
                {
                    Id = PlantationSite.Id,
                    Zones = zones,
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                });

            for(int i = 1; i < 4; i++)
            {
                ZoneDTO zone = new ZoneDTO() { Id=1, PlantationSiteId=PlantationSite.Id, TreeId=Tree.Id};
                zonesDTO.Add(zone);
            }

            AddZonesManyCommand command = new AddZonesManyCommand
            {
                Zones = zonesDTO
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zones.All(zone => zone.Id == 0)).WithErrorMessage("All id's should be zero when adding a zone.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_PlantationSiteId_Zero()
        {
            List<ZoneDTO> Zones = new List<ZoneDTO>();

            List<Domain.Zone> zones = new List<Domain.Zone>();

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.PlantationSite()
                {
                    Id = PlantationSite.Id,
                    Zones = zones,
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                });

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

            List<Domain.Zone> zones = new List<Domain.Zone>();

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.PlantationSite()
                {
                    Id = PlantationSite.Id,
                    Zones = zones,
                    Street = "Street",
                    Name = "Name",
                    HouseNumber = "1",
                    GroundPlan = "",
                    Country = "Country",
                    City = "City"
                });

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

        [TestMethod]
        public async Task Should_Have_Error_With_Duplicate_Zone_Name_In_Db()
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


            AddZonesManyCommand command = new AddZonesManyCommand()
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id }
                }
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

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

            AddZonesManyCommand command2 = new AddZonesManyCommand()
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id }
                }
            };

            TestValidationResult<AddZonesManyCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            Assert.IsTrue(result2.ShouldHaveValidationErrorFor(command => command.Zones).WithErrorMessage("The zone name must be unique within a plantationsite") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_With_Duplicate_Zone_Name_In_List()
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


            AddZonesManyCommand command = new AddZonesManyCommand()
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id },
                    new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id },
                }
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zones).WithErrorMessage("The zone name must be unique within a plantationsite") != null);
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


            AddZonesManyCommand command = new AddZonesManyCommand()
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id },
                    new ZoneDTO() { Id = 0, Name = "Zone2", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id },
                }
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

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

            zones.Add(new Domain.Zone() 
                {
                    Id = 2,
                    Name = "Zone2",
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

            AddZonesManyCommand command2 = new AddZonesManyCommand()
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 0, Name = "Zone3", TreeId = Tree.Id, PlantationSiteId = plantationSite.Id }
                }
            };

            TestValidationResult<AddZonesManyCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            result2.ShouldNotHaveAnyValidationErrors();
        }
    }
}
