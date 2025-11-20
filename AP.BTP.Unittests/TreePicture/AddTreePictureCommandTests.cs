using AP.BTP.Application.CQRS.TreePicture;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.TreePicture
{
    [TestClass]
    public class AddTreePictureCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITreeRepository> treeRepoMock;
        private AddTreePictureCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            treeRepoMock = new Mock<ITreeRepository>();

            uowMock.Setup(u => u.TreeRepository).Returns(treeRepoMock.Object);

            validator = new AddTreePictureCommandValidator(uowMock.Object);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Path_Is_Empty()
        {
            AddTreePictureCommand command = new AddTreePictureCommand
            {
                TreePicture = new TreePictureDTO 
                { 
                    Path = "", 
                    TreeId = 1,
                    IsFavourite = false
                }
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.TreePicture.Path)
                .WithErrorMessage("Picture path cannot be empty.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_TreeId_Is_Invalid()
        {
            AddTreePictureCommand command = new AddTreePictureCommand
            {
                TreePicture = new TreePictureDTO 
                { 
                    Path = "test.jpg", 
                    TreeId = 0,
                    IsFavourite = false
                }
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.TreePicture.TreeId)
                .WithErrorMessage("Invalid TreeId.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Tree_Does_Not_Exist()
        {
            treeRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                        .ReturnsAsync((Domain.Tree?)null);

            AddTreePictureCommand command = new AddTreePictureCommand
            {
                TreePicture = new TreePictureDTO 
                { 
                    Path = "photo.jpg", 
                    TreeId = 10,
                    IsFavourite = false
                }
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.TreePicture.TreeId)
                .WithErrorMessage("Tree does not exist.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_File_Extension_Is_Invalid()
        {
            treeRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                        .ReturnsAsync(new Domain.Tree(){ Id = 1, Species = "Test", IsDeleted = false});

            AddTreePictureCommand command = new AddTreePictureCommand
            {
                TreePicture = new TreePictureDTO 
                { 
                    Path = "file.txt", 
                    TreeId = 1,
                    IsFavourite = false
                }
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.TreePicture.Path)
                .WithErrorMessage("Unsupported image file type.");
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Input_Is_Valid()
        {
            treeRepoMock.Setup(r => r.GetById(It.IsAny<int>()))
                        .ReturnsAsync(new Domain.Tree(){ Id = 1, Species = "Test", IsDeleted = false});

            AddTreePictureCommand command = new AddTreePictureCommand
            {
                TreePicture = new TreePictureDTO
                {
                    Path = "image.png",
                    TreeId = 3,
                    IsFavourite = false
                }
            };

            var result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
