
using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests
{
    [TestClass]
    public class AddPlantationSiteCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<IPlantationSiteRepository> plantantationSiteRepoMock;
        private AddPlantationSiteCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            plantantationSiteRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantantationSiteRepoMock.Object);

            validator = new AddPlantationSiteCommandValidator(uowMock.Object);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Not_Zero()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 5,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "A15",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    IsDeleted = false
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
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    IsDeleted = false
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
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    IsDeleted = false
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
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    IsDeleted = false
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
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "12345678910",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    IsDeleted = false
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
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "A15aAaa",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    IsDeleted = false
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
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    IsDeleted = false
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
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 100,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    IsDeleted = false
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
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "",
                    GroundPlan = "Groundplan",
                    IsDeleted = false
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
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "",
                    IsDeleted = false
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.GroundPlan).WithErrorMessage("Groundplan cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_IsDeleted_True()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    IsDeleted = true
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.PlantationSite.IsDeleted).WithErrorMessage("Plantation site cannot be created as 'deleted'.") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_PlantationSiteDTO_Is_Valid()
        {
            AddPlantationSiteCommand command = new AddPlantationSiteCommand
            {
                PlantationSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    IsDeleted = false
                }
            };

            TestValidationResult<AddPlantationSiteCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}