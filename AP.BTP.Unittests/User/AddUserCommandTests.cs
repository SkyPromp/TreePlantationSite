using AP.BTP.Application.CQRS.User;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using FluentValidation.TestHelper;
using Moq;

namespace AP.BTP.Unittests.User
{
    [TestClass]
    public class AddUserCommandTests
    {
        private Mock<IUnitOfWork> uowMock;
        private AddUserCommandValidator validator;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            validator = new AddUserCommandValidator(uowMock.Object);
        }

        private AddUserCommand CreateValidCommand()
        {
            return new AddUserCommand
            {
                User = new RegisterUserDTO
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@example.com",
                    PhoneNumber = "+32123456789",
                    Password = "Password1!",
                    ConfirmPassword = "Password1!"
                }
            };
        }

        [TestMethod]
        public async Task Should_Have_Error_When_FirstName_Empty()
        {
            AddUserCommand command = CreateValidCommand();
            command.User.FirstName = "";

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.User.FirstName)
                .WithErrorMessage("Voornaam is verplicht.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_LastName_Empty()
        {
            AddUserCommand command = CreateValidCommand();
            command.User.LastName = "";

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.User.LastName)
                .WithErrorMessage("Achternaam is verplicht.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Email_Invalid()
        {
            AddUserCommand command = CreateValidCommand();
            command.User.Email = "invalid-email";

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.User.Email)
                .WithErrorMessage("Ongeldig e-mailadres.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_PhoneNumber_Invalid()
        {
            AddUserCommand command = CreateValidCommand();
            command.User.PhoneNumber = "abc123";

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.User.PhoneNumber)
                .WithErrorMessage("Ongeldig telefoonnummer.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Password_Missing_Uppercase()
        {
            AddUserCommand command = CreateValidCommand();
            command.User.Password = "password1!";
            command.User.ConfirmPassword = "password1!";

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.User.Password)
                .WithErrorMessage("Wachtwoord moet minimaal 1 hoofdletter bevatten.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Password_Missing_Lowercase()
        {
            AddUserCommand command = CreateValidCommand();
            command.User.Password = "PASSWORD1!";
            command.User.ConfirmPassword = "PASSWORD1!";

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.User.Password)
                .WithErrorMessage("Wachtwoord moet minimaal 1 kleine letter bevatten.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Password_Missing_Number()
        {
            AddUserCommand command = CreateValidCommand();
            command.User.Password = "Password!";
            command.User.ConfirmPassword = "Password!";

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.User.Password)
                .WithErrorMessage("Wachtwoord moet minimaal 1 nummer bevatten.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_Password_Missing_Special_Char()
        {
            AddUserCommand command = CreateValidCommand();
            command.User.Password = "Password1";
            command.User.ConfirmPassword = "Password1";

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.User.Password)
                .WithErrorMessage("Wachtwoord moet minimaal 1 speciaal teken bevatten.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_ConfirmPassword_Does_Not_Match()
        {
            AddUserCommand command = CreateValidCommand();
            command.User.ConfirmPassword = "Different1!";

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.User.ConfirmPassword)
                .WithErrorMessage("Wachtwoorden komen niet overeen.");
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Command_Is_Valid()
        {
            AddUserCommand command = CreateValidCommand();

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
