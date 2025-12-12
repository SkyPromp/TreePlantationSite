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
        private Mock<IUnitOfWork> uowMock = null!;
        private Mock<IUserRepository> userRepoMock = null!;
        private AddUserCommandValidator validator = null!;

        [TestInitialize]
        public void Setup()
        {
            uowMock = new Mock<IUnitOfWork>();
            userRepoMock = new Mock<IUserRepository>();

            userRepoMock.Setup(x => x.IsEmailUnique(It.IsAny<string>()))
                        .ReturnsAsync(true);
            userRepoMock.Setup(x => x.IsFullNameUnique(It.IsAny<string>(), It.IsAny<string>()))
                        .ReturnsAsync(true);

            uowMock.Setup(u => u.UserRepository).Returns(userRepoMock.Object);

            validator = new AddUserCommandValidator(uowMock.Object);
        }

        private static AddUserCommand CreateValidCommand()
        {
            return new AddUserCommand
            {
                User = new RegisterUserDto
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@example.com",
                    PhoneNumber = "+32123456789",
                    Password = "Password1!",
                    ConfirmPassword = "Password1!",
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

        [TestMethod]
        public async Task Should_Have_Error_When_Email_Not_Unique()
        {
            AddUserCommand command = CreateValidCommand();

            userRepoMock.Setup(x => x.IsEmailUnique(command.User.Email))
                        .ReturnsAsync(false);

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x.User.Email)
                .WithErrorMessage("E-mailadres is al in gebruik.");
        }

        [TestMethod]
        public async Task Should_Have_Error_When_FullName_Not_Unique()
        {
            AddUserCommand command = CreateValidCommand();

            userRepoMock.Setup(x => x.IsFullNameUnique(command.User.FirstName, command.User.LastName))
                        .ReturnsAsync(false);

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldHaveValidationErrorFor(x => x)
                .WithErrorMessage("Een gebruiker met deze voornaam en achternaam bestaat al.");
        }

        [TestMethod]
        public async Task Should_Not_Have_Error_When_Email_And_FullName_Are_Unique()
        {
            AddUserCommand command = CreateValidCommand();

            TestValidationResult<AddUserCommand> result = await validator.TestValidateAsync(command);

            result.ShouldNotHaveValidationErrorFor(x => x.User.Email);
            result.ShouldNotHaveValidationErrorFor(x => x.User.FirstName);
        }
    }
}
