using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    /// <summary>
    /// Command to attempt a login using email + password.
    /// </summary>
    public class LoginUserCommand : IRequest<TokenResponseDTO?>
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be valid.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, TokenResponseDTO?>
    {
        private readonly IAuth0PasswordGrantService passwordGrant;

        public LoginUserCommandHandler(IAuth0PasswordGrantService passwordGrant)
        {
            this.passwordGrant = passwordGrant;
        }

        public async Task<TokenResponseDTO?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await passwordGrant.LoginAsync(request.Email, request.Password);
        }
    }
}
