using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AP.BTP.Domain;
using FluentValidation;
using MediatR;
using System.IdentityModel.Tokens.Jwt;

namespace AP.BTP.Application.CQRS.User
{
    /// <summary>
    /// Command to attempt a login using email + password.
    /// </summary>
    public class LoginUserCommand : IRequest<LoginResponseDTO?>
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

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDTO?>
    {
        private readonly IAuth0PasswordGrantService passwordGrant;
        private readonly IUserRepository userRepository;

        public LoginUserCommandHandler(IAuth0PasswordGrantService passwordGrant, IUserRepository userRepository)
        {
            this.passwordGrant = passwordGrant;
            this.userRepository = userRepository;
        }

        public async Task<LoginResponseDTO?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            TokenResponseDTO? tokens = await passwordGrant.LoginAsync(request.Email, request.Password);

            if (tokens == null)
                return null;

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwt = handler.ReadJwtToken(tokens.id_token);
            string auth0UserId = jwt.Claims.First(c => c.Type == "sub").Value;

            Domain.User? user = await userRepository.GetUserByAuth0Id(auth0UserId);

            if (user == null)
                return null;

            LoginResponseDTO loginResponse = new LoginResponseDTO
            {
                access_token = tokens.access_token,
                refresh_token = tokens.refresh_token,
                id_token = tokens.id_token,
                token_type = tokens.token_type,
                expires_in = tokens.expires_in,
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return loginResponse;
        }
    }
}
