using AP.BTP.Application.CQRS.TreePicture;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace AP.BTP.Unittests.TreePicture
{
    [TestClass]
    public class DeleteTreePictureCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITreePictureRepository> treePictureRepoMock;
        private DeleteTreePictureCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            treePictureRepoMock = new Mock<ITreePictureRepository>();

            uowMock.Setup(u => u.TreePictureRepository).Returns(treePictureRepoMock.Object);

            validator = new DeleteTreePictureCommandValidator(uowMock.Object);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Less_Than_1()
        {
            DeleteTreePictureCommand command = new DeleteTreePictureCommand { Id = 0 };

            treePictureRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Domain.TreePicture?)null);

            TestValidationResult<DeleteTreePictureCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.Id)
                .WithErrorMessage("Invalid picture Id.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Picture_Does_Not_Exist()
        {
            DeleteTreePictureCommand command = new DeleteTreePictureCommand { Id = 1 };

            treePictureRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Domain.TreePicture?)null);

            TestValidationResult<DeleteTreePictureCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(c => c.Id)
                .WithErrorMessage("TreeDTO picture does not exist.");
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Picture_Exists()
        {
            DeleteTreePictureCommand command = new DeleteTreePictureCommand { Id = 1 };

            treePictureRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Domain.TreePicture { Id = 1, Path = "test.jpg", TreeId = 1 , Tree = new Domain.Tree(){Id = 1, Species = "Test" , IsDeleted = false}});

            TestValidationResult<DeleteTreePictureCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Handler_Should_Delete_Picture_When_Exists()
        {
            Domain.TreePicture picture = new Domain.TreePicture { Id = 1, Path = "test.jpg", TreeId = 1, Tree = new Domain.Tree(){Id = 1, Species = "Test" , IsDeleted = false}};
            treePictureRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(picture);

            DeleteTreePictureCommandHandler handler = new DeleteTreePictureCommandHandler(uowMock.Object);

            await handler.Handle(new DeleteTreePictureCommand { Id = 1 }, default);

            treePictureRepoMock.Verify(r => r.Delete(It.Is<Domain.TreePicture>(p => p == picture)), Times.Once);
            uowMock.Verify(u => u.Commit(), Times.Once);
        }

        [TestMethod]
        public async Task Handler_Should_Not_Throw_When_Picture_Does_Not_Exist()
        {
            treePictureRepoMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Domain.TreePicture?)null);

            DeleteTreePictureCommandHandler handler = new DeleteTreePictureCommandHandler(uowMock.Object);

            await handler.Handle(new DeleteTreePictureCommand { Id = 1 }, default);

            treePictureRepoMock.Verify(r => r.Delete(It.IsAny<Domain.TreePicture>()), Times.Never);
            uowMock.Verify(u => u.Commit(), Times.Once);
        }
    }
}
