using AP.BTP.Application.CQRS.TreePicture;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.TreePicture
{
    [TestClass]
    public class PatchTreePictureCommandTests
    {
        private Mock<IUnitOfWork> uowMock = null!;
        private Mock<ITreePictureRepository> treePictureRepoMock = null!;
        private PatchTreePictureCommandValidator validator = null!;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            treePictureRepoMock = new Mock<ITreePictureRepository>();
            uowMock.Setup(u => u.TreePictureRepository).Returns(treePictureRepoMock.Object);

            validator = new PatchTreePictureCommandValidator(uowMock.Object);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Less_Than_1()
        {
            PatchTreePictureCommand command = new PatchTreePictureCommand { TreePictureId = 0, IsFavourite = true };

            TestValidationResult<PatchTreePictureCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.TreePictureId)
                  .WithErrorMessage("TreePictureId must be greater than zero.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Picture_Does_Not_Exist()
        {
            PatchTreePictureCommand command = new PatchTreePictureCommand { TreePictureId = 1, IsFavourite = true };

            treePictureRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Domain.TreePicture?)null);

            TestValidationResult<PatchTreePictureCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.TreePictureId)
                  .WithErrorMessage("TreePicture not found.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Another_Favourite_Exists()
        {
            PatchTreePictureCommand command = new PatchTreePictureCommand { TreePictureId = 2, IsFavourite = true };

            Domain.TreePicture existingFavourite = new Domain.TreePicture { Id = 1, IsFavourite = true, TreeId = 1, Path = "", Tree = null! };
            Domain.TreePicture targetPicture = new Domain.TreePicture { Id = 2, IsFavourite = false, TreeId = 1, Path = "", Tree = null!};

            treePictureRepoMock.Setup(r => r.GetById(2)).ReturnsAsync(targetPicture);
            treePictureRepoMock.Setup(r => r.GetAllByTreeId(1))
                               .ReturnsAsync(new List<Domain.TreePicture> { existingFavourite, targetPicture });

            TestValidationResult<PatchTreePictureCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c)
                  .WithErrorMessage("Only one picture per tree can be set as favourite.");
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Valid()
        {
            PatchTreePictureCommand command = new PatchTreePictureCommand { TreePictureId = 1, IsFavourite = true };
            Domain.TreePicture picture = new Domain.TreePicture { Id = 1, IsFavourite = false, TreeId = 1, Path = "", Tree = null!};

            treePictureRepoMock.Setup(r => r.GetById(1)).ReturnsAsync(picture);
            treePictureRepoMock.Setup(r => r.GetAllByTreeId(1)).ReturnsAsync(new List<Domain.TreePicture> { picture });

            TestValidationResult<PatchTreePictureCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
