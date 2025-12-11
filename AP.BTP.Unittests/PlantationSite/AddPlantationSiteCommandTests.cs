using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.PlantationSite
{
    [TestClass]
    public class AddPlantationSiteCommandTests
    {
        private Mock<IUnitOfWork> uowMock = null!;
        private Mock<IPlantationSiteRepository> plantantationSiteRepoMock = null!;
        private AddPlantationSiteCommandValidator validator = null!;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            plantantationSiteRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantantationSiteRepoMock.Object);

            validator = new AddPlantationSiteCommandValidator(uowMock.Object);
        }

        private static TreeDto TreeDTO 
        {
            get
            {
                return new TreeDto() { Id = 1, Species = "Oak" };
            }
        }

        private static PlantationSiteDto PlantationSiteDTO { 
            get
            {
                return new PlantationSiteDto() { Id = 1, City = "", Country = "", GroundPlan = "", HouseNumber = "", Name = "", Street = "", Zones=new List<ZoneDto>(), Size=100 };
            }
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Not_Zero()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 5,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "A15",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.Id).WithErrorMessage("Id cannot be manually assigned.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Name_Empty()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.Name).WithErrorMessage("Name cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Street_Empty()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "Test",
                    Street = "",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.Street).WithErrorMessage("Street cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_HouseNumber_Empty()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.HouseNumber).WithErrorMessage("'Plantation Site House Number' must not be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_HouseNumber_Too_Long()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "12345678910",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.HouseNumber).WithErrorMessage("The length of 'Plantation Site House Number' must be 10 characters or fewer. You entered 11 characters.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_HouseNumber_Invalid_Format()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "A15aAaa",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.HouseNumber).WithErrorMessage("Invalid house number format.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_City_Empty()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.City).WithErrorMessage("City cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_PostalCode_Invalid()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 100,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.PostalCode).WithErrorMessage("Postal code must be between 1000 and 9999.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Country_Empty()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "",
                    GroundPlan = "Groundplan",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.Country).WithErrorMessage("Country cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_GroundPlan_Empty()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.GroundPlan).WithErrorMessage("Groundplan cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Size_Negative()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = -200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.Size).WithErrorMessage("Size must be zero or positive.") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_PlantationSiteDTO_Is_Valid()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDto
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Total_Zone_Size_Is_Smaller_Than_The_PlantationSite_Size()
        {
            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            PlantationSiteDto plantationSiteDTO = PlantationSiteDTO;
            plantationSiteDTO.Zones = new List<ZoneDto>();
            plantationSiteDTO.Size = 100;

            plantationSiteDTO.Zones.Add(
                new ZoneDto()
                {
                    Id = 1,
                    Name = "Zone",
                    Size = 40,
                    TreeId = TreeDTO.Id,
                    PlantationSiteId = PlantationSiteDTO.Id,
                }
            );

            plantationSiteDTO.Zones.Add(
                new ZoneDto()
                {
                    Id = 2,
                    Name = "Zone 2",
                    Size = 40,
                    TreeId = TreeDTO.Id,
                    PlantationSiteId = PlantationSiteDTO.Id,
                }
            );

            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = plantationSiteDTO
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveValidationErrorFor(command => command.PlantationSite);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Total_Zone_Size_Is_Bigger_Than_The_PlantationSite_Size()
        {
            Mock<IPlantationSiteRepository> plantationRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationRepoMock.Object);

            PlantationSiteDto plantationSiteDTO = PlantationSiteDTO;
            plantationSiteDTO.Zones = new List<ZoneDto>();
            plantationSiteDTO.Size = 60;

            plantationSiteDTO.Zones.Add(
                new ZoneDto()
                {
                    Id = 1,
                    Name = "Zone",
                    Size = 40,
                    TreeId = TreeDTO.Id,
                    PlantationSiteId = PlantationSiteDTO.Id,
                }
            );

            plantationSiteDTO.Zones.Add(
                new ZoneDto()
                {
                    Id = 2,
                    Name = "Zone 2",
                    Size = 40,
                    TreeId = TreeDTO.Id,
                    PlantationSiteId = PlantationSiteDTO.Id,
                }
            );

            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = plantationSiteDTO
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite).WithErrorMessage("The sum of the area of the zones must be smaller or equal to the total size of the plantationSite") != null);
        }
    }
}