using AP.BTP.Application.CQRS.User;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.User
{
    [TestClass]
    public class LinkUserToPlantationSitesCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<IUserRepository> userRepoMock;
        private Mock<IPlantationSiteRepository> plantationSiteRepoMock;
        private LinkUserToPlantationSitesCommandValidator validator;
        private Domain.PlantationSite? plantationSite;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            userRepoMock = new Mock<IUserRepository>();
            plantationSiteRepoMock = new Mock<IPlantationSiteRepository>();

            uowMock.Setup(u => u.UserRepository).Returns(userRepoMock.Object);
            uowMock.Setup(u => u.PlantationSiteRepository).Returns(plantationSiteRepoMock.Object);

            validator = new LinkUserToPlantationSitesCommandValidator(uowMock.Object);

            plantationSite = new Domain.PlantationSite
            {
                Id = 1,
                Name = "Test Site",
                Street = "Test Street",
                HouseNumber = "1A",
                City = "Test City",
                PostalCode = 12345,
                Country = "Test Country",
                Size = 100.0,
                GroundPlan = "TestPlan",
                IsDeleted = false
            };

            userRepoMock
            .Setup(r => r.GetById(It.IsAny<int>()))
            .ReturnsAsync(new Domain.User
            {
                Id = 1,
                Auth0Id = "auth0|test",
                PlantationSites = new List<Domain.PlantationSite>()
            });
        }

        [TestMethod]
        public async Task Should_Have_Error_When_List_Has_more_than_2_Items()
        {
            LinkUserToPlantationSitesCommand command = new LinkUserToPlantationSitesCommand
            {
                UserId = 1,
                PlantationSiteIds = new List<int> { 1, 2, 3 }
            };

            TestValidationResult<LinkUserToPlantationSitesCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.PlantationSiteIds)
                  .WithErrorMessage("Users can only have a maximum of 2 plantation sites.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_PlantationSite_Does_Not_Exist()
        {
            LinkUserToPlantationSitesCommand command = new LinkUserToPlantationSitesCommand
            {
                UserId = 1,
                PlantationSiteIds = new List<int> { 1, 2 }
            };
            plantationSiteRepoMock
                .Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    if (id == 1)
                        return plantationSite;
                    return null;
                });

            TestValidationResult<LinkUserToPlantationSitesCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.PlantationSiteIds)
                  .WithErrorMessage("Plantation site with id 2 does not exist.");
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_All_PlantationSites_Exist()
        {
            LinkUserToPlantationSitesCommand command = new LinkUserToPlantationSitesCommand
            {
                UserId = 1,
                PlantationSiteIds = new List<int> { 1, 2 }
            };

            plantationSiteRepoMock
                .Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(plantationSite);

            TestValidationResult<LinkUserToPlantationSitesCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_List_Has_0_Items()
        {
            LinkUserToPlantationSitesCommand command = new LinkUserToPlantationSitesCommand
            {
                UserId = 1,
                PlantationSiteIds = new List<int>()
            };

            plantationSiteRepoMock
                .Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(plantationSite);

            TestValidationResult<LinkUserToPlantationSitesCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_List_Has_1_Items()
        {
            LinkUserToPlantationSitesCommand command = new LinkUserToPlantationSitesCommand
            {
                UserId = 1,
                PlantationSiteIds = new List<int> { 1 }
            };

            plantationSiteRepoMock
                .Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(plantationSite);

            TestValidationResult<LinkUserToPlantationSitesCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
