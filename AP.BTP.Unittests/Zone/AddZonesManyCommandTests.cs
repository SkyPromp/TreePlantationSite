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
            List<ZoneDTO> zonesDTO = new List<ZoneDTO>();
            List<Domain.Zone> zones = new List<Domain.Zone>();

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.PlantationSite()
                {
                    Id = PlantationSiteDTO.Id,
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
                ZoneDTO zone = new ZoneDTO() { Id=1, PlantationSiteId=PlantationSiteDTO.Id, TreeId=TreeDTO.Id};
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
                    Id = PlantationSiteDTO.Id,
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
                ZoneDTO zone = new ZoneDTO() { Id=1, PlantationSiteId=0, TreeId=TreeDTO.Id};
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

            Domain.PlantationSite plantationSite = PlantationSite;

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(plantationSite);

            for(int i = 1; i < 4; i++)
            {
                ZoneDTO zone = new ZoneDTO() { Id=1, PlantationSiteId=PlantationSiteDTO.Id, TreeId=0, Size=1};
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
            PlantationSiteDTO plantationSiteDTO = PlantationSiteDTO;
            Domain.PlantationSite plantationSite = PlantationSite;

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(plantationSite);


            AddZonesManyCommand command = new AddZonesManyCommand()
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size=1 }
                }
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

            plantationSite.Zones.Add(new Domain.Zone() 
            {
                    Id = 1,
                    Name = "Zone1",
                    Tree = new Domain.Tree() { Id = 1, Species = "Oak" },
                    PlantationSite = plantationSite,
                    Size = 1
            });

            AddZonesManyCommand command2 = new AddZonesManyCommand()
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id }
                }
            };

            TestValidationResult<AddZonesManyCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            Assert.IsTrue(result2.ShouldHaveValidationErrorFor(command => command.Zones).WithErrorMessage("The zone name must be unique within a plantationsite.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_With_Duplicate_Zone_Name_In_List()
        {
            PlantationSiteDTO plantationSite = PlantationSiteDTO;
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
                    new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSite.Id },
                    new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSite.Id },
                }
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zones).WithErrorMessage("The zone name must be unique within a plantationsite.") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_Without_Duplicate_Zone_Name()
        {
            PlantationSiteDTO plantationSiteDTO = PlantationSiteDTO;
            Domain.PlantationSite plantationSite = PlantationSite;

            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            plantationRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(plantationSite);


            AddZonesManyCommand command = new AddZonesManyCommand()
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 0, Name = "Zone1", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size=1 },
                    new ZoneDTO() { Id = 0, Name = "Zone2", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size=1 },
                }
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

            plantationSite.Zones.Add(new Domain.Zone() 
            {
                Id = 1,
                Name = "Zone1",
                Tree = new Domain.Tree() { Id = 1, Species = "Oak" },
                Size = 1,
                PlantationSite = plantationSite
            });

            plantationSite.Zones.Add(new Domain.Zone() 
            {
                Id = 2,
                Name = "Zone2",
                Tree = new Domain.Tree() { Id = 1, Species = "Oak" },
                PlantationSite = plantationSite
            });

            AddZonesManyCommand command2 = new AddZonesManyCommand()
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 0, Name = "Zone3", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 1 }
                }
            };

            TestValidationResult<AddZonesManyCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            result2.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Total_Zone_Size_Is_Smaller_Than_The_PlantationSite_Size()
        {
            PlantationSiteDTO plantationSiteDTO = PlantationSiteDTO;

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

            AddZonesManyCommand command = new AddZonesManyCommand()
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 2, Name = "Zone3", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 1 },
                    new ZoneDTO() { Id = 4, Name = "Zone4", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 1 }
                }
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveValidationErrorFor(command => command.Zones);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Total_Zone_Size_Is_Bigger_Than_The_PlantationSite_Size()
        {
            PlantationSiteDTO plantationSiteDTO = PlantationSiteDTO;
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

            AddZonesManyCommand command = new AddZonesManyCommand
            {
                Zones = new List<ZoneDTO>()
                {
                    new ZoneDTO() { Id = 2, Name = "Zone3", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 40 },
                    new ZoneDTO() { Id = 4, Name = "Zone4", TreeId = TreeDTO.Id, PlantationSiteId = plantationSiteDTO.Id, Size = 40 }
                }
            };

            TestValidationResult<AddZonesManyCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Zones).WithErrorMessage("The sum of all the zone sizes must be smaller than the total plantationsite area.") != null);
        }
    }
}
