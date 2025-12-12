using System.Reflection;
using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.Tree
{
    [TestClass]
    public class AddTreeCommandTests
    {
        private Mock<IUnitOfWork> uowMock = null!;
        private Mock<ITreeRepository> treeRepoMock = null!;
        private AddTreeCommandValidator validator = null!;

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
                Tree = new TreeDto() { Id = 0, Species = "" }
            };

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Tree.Species).WithErrorMessage("Species name is required.") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Species_Filled_In()
        {
            AddTreeCommand command = new AddTreeCommand
            {
                Tree = new TreeDto() { Id = 0, Species = "Oak" }
            };

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Id_Not_Zero()
        {
            AddTreeCommand command = new AddTreeCommand
            {
                Tree = new TreeDto() { Id = 1, Species = "Oak" }
            };

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            Assert.IsTrue(result.ShouldHaveValidationErrorFor(command => command.Tree.Id).WithErrorMessage("Id should be zero when adding a tree.") != null);
        }

        [TestMethod]
        public async Task Should_Have_Error_With_Duplicate_Tree_Species()
        {
            List<Domain.Tree> trees = new List<Domain.Tree>();

            treeRepoMock.Setup(r => r.GetAll()).ReturnsAsync(trees);

            AddTreeCommand command = new AddTreeCommand
            {
                Tree = new TreeDto() { Id = 0, Species = "Oak" }
            };

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            trees.Add(new Domain.Tree() 
                {
                    Id = 1,
                    Species = "Oak"
                }
            );

            AddTreeCommand command2 = new AddTreeCommand
            {
                Tree = new TreeDto() { Id = 0, Species = "Oak" }
            };

            TestValidationResult<AddTreeCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            Assert.IsTrue(result2.ShouldHaveValidationErrorFor(command => command.Tree).WithErrorMessage("The tree species must be unique.") != null);
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_Without_Duplicate_Tree_Species()
        {
            List<Domain.Tree> trees = new List<Domain.Tree>();
            
            treeRepoMock.Setup(r => r.GetAll()).ReturnsAsync(trees);

            AddTreeCommand command = new AddTreeCommand
            {
                Tree = new TreeDto() { Id = 0, Species = "Oak" }
            };

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            trees.Add(new Domain.Tree() 
                {
                    Id = 1,
                    Species = "Oak"
                }
            );

            AddTreeCommand command2 = new AddTreeCommand
            {
                Tree = new TreeDto() { Id = 0, Species = "Birch" }
            };

            TestValidationResult<AddTreeCommand> result2 = await validator.TestValidateAsync(command2);

            result.ShouldNotHaveAnyValidationErrors();
            result2.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        [DataRow("MaintenancePlanSpring")]
        [DataRow("MaintenancePlanSummer")]
        [DataRow("MaintenancePlanAutumn")]
        [DataRow("MaintenancePlanWinter")]
        public async Task Should_Have_Error_When_Unsupported_File_Type(string propertyName)
        {
            AddTreeCommand command = new AddTreeCommand
            {
                Tree = new TreeDto
                {
                    Id = 0,
                    Species = "Oak"
                }
            };

            SetProperty(command.Tree, propertyName, "file.exe");

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor($"Tree.{propertyName}");
        }

        [TestMethod]
        [DataRow("MaintenancePlanSpring")]
        [DataRow("MaintenancePlanSummer")]
        [DataRow("MaintenancePlanAutumn")]
        [DataRow("MaintenancePlanWinter")]
        public async Task Should_Not_Have_Error_When_Supported_File_Type(string propertyName)
        {
            AddTreeCommand command = new AddTreeCommand
            {
                Tree = new TreeDto
                {
                    Id = 0,
                    Species = "Oak"
                }
            };

            SetProperty(command.Tree, propertyName, "document.pdf");

            TestValidationResult<AddTreeCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveValidationErrorFor($"TreeDTO.{propertyName}");
        }

        private static void SetProperty(TreeDto tree, string propertyName, string value)
        {
            PropertyInfo property = typeof(TreeDto).GetProperty(propertyName)
                ?? throw new ArgumentException($"Property {propertyName} not found on TreeDTO");

            property.SetValue(tree, value);
        }
    }
}
