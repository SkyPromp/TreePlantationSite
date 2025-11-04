
using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests
{
    [TestClass]
    public class UpdatePlantationSiteCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<IPlantationSiteRepository> plantantationSiteRepoMock;
        private UpdatePlantationSiteCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            plantantationSiteRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantantationSiteRepoMock.Object);

            validator = new UpdatePlantationSiteCommandValidator(uowMock.Object);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Name_Empty()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.Name).WithErrorMessage("Name cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Street_Empty()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.Street).WithErrorMessage("Street cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_HouseNumber_Empty()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.HouseNumber).WithErrorMessage("'Updated Site House Number' must not be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_HouseNumber_Too_Long()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "12345678910",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.HouseNumber).WithErrorMessage("The length of 'Updated Site House Number' must be 10 characters or fewer. You entered 11 characters.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_HouseNumber_Invalid_Format()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "A15aAaa",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.HouseNumber).WithErrorMessage("Invalid house number format.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_City_Empty()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.City).WithErrorMessage("City cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_PostalCode_Invalid()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 100,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.PostalCode).WithErrorMessage("Postal code must be between 1000 and 9999.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Country_Empty()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "",
                    GroundPlan = "Groundplan",
                    Size = 200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.Country).WithErrorMessage("Country cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_GroundPlan_Empty()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "",
                    Size = 200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.GroundPlan).WithErrorMessage("Groundplan cannot be empty.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_IsDeleted_True()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0,
                    IsDeleted = true
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.IsDeleted).WithErrorMessage("Plantation site cannot be updated as 'deleted'.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Size_Negative()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = -200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.UpdatedSite.Size).WithErrorMessage("Size must be zero or positive.") != null);
        } 

        [TestMethod]
        public async Task Should_Not_Have_Error_When_PlantationSiteDTO_Is_Valid()
        {
            UpdatePlantationSiteCommand command = new UpdatePlantationSiteCommand
            {
                UpdatedSite = new PlantationSiteDTO
                {
                    Id = 0,
                    Name = "Test",
                    Street = "Street",
                    HouseNumber = "15A",
                    City = "City",
                    PostalCode = 5555,
                    Country = "Country",
                    GroundPlan = "Groundplan",
                    Size = 200.0,
                    IsDeleted = false
                }
            };

            TestValidationResult<UpdatePlantationSiteCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}