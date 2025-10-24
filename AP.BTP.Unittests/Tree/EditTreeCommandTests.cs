using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.Tree
{
    [TestClass]
    public class EditTreeCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITreeRepository> treeRepoMock;
        private EditTreeCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            treeRepoMock = new Mock<ITreeRepository>();

            uowMock.Setup(u => u.TreeRepository).Returns(treeRepoMock.Object);

            validator = new EditTreeCommandValidator(uowMock.Object);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Species_Empty()
        {
            EditTreeCommand command = new EditTreeCommand
            {
                Tree = new TreeDTO() { Id = 1, Species = "" }
            };

            TestValidationResult<EditTreeCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Tree.Species).WithErrorMessage("Species name is required.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Species_Missing()
        {
            EditTreeCommand command = new EditTreeCommand
            {
                Tree = new TreeDTO() { Id = 1, Species = null }
            };

            TestValidationResult<EditTreeCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Tree.Species).WithErrorMessage("Species name is required.") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Species_Filled_In()
        {
            EditTreeCommand command = new EditTreeCommand
            {
                Tree = new TreeDTO() { Id = 1, Species = "Oak" }
            };

            TestValidationResult<EditTreeCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Not_Zero()
        {
            EditTreeCommand command = new EditTreeCommand
            {
                Tree = new TreeDTO() { Id = 0, Species = "Oak" }
            };

            TestValidationResult<EditTreeCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Tree.Id).WithErrorMessage("Id should not be zero when editing a tree.") != null);
        }
    }
}
