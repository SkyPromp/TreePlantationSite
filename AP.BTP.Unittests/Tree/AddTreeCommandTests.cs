using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.Interfaces;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.Tree
{
    [TestClass]
    public class AddTreeCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<ITreeRepository> treeRepoMock;
        private AddTreeCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            treeRepoMock = new Mock<ITreeRepository>();

            uowMock.Setup(u => u.TreeRepository).Returns(treeRepoMock.Object);

            validator = new AddTreeCommandValidator(uowMock.Object);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Species_Empty()
        {
            AddTreeCommand command = new AddTreeCommand
            {
                Tree = new TreeDTO() { Id = 0, Species = "" }
            };

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Tree.Species).WithErrorMessage("Species name is required.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Species_Missing()
        {
            AddTreeCommand command = new AddTreeCommand
            {
                Tree = new TreeDTO() { Id = 0, Species = null }
            };

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Tree.Species).WithErrorMessage("Species name is required.") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Species_Filled_In()
        {
            AddTreeCommand command = new AddTreeCommand
            {
                Tree = new TreeDTO() { Id = 0, Species = "Oak" }
            };

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Not_Zero()
        {
            AddTreeCommand command = new AddTreeCommand
            {
                Tree = new TreeDTO() { Id = 1, Species = "Oak" }
            };

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Tree.Id).WithErrorMessage("Id should be zero when adding a tree.") != null);
        }
    }
}
