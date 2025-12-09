using AP.BTP.Application.Exceptions;
using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AP.BTP.Contracts.Enums;
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
        /// <summary>
        /// The user's email address used for login.
        /// </summary>
        public string Email { get; set; } = "";

        /// <summary>
        /// The user's password used for login.
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>
        /// Whether the user that wants to login is for the maintenance app.
        /// </summary>
        public bool? IsForMaintenance { get; set; } = null;
    }

    /// <summary>
    /// Provides validation rules for the <see cref="LoginUserCommand"/>.
    /// Ensures that email and password are not empty, and that the email is in a valid format.
    /// </summary>
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginUserCommandValidator"/> class.
        /// Configures rules for email and password validation.
        /// </summary>
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be valid.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(x => x.IsForMaintenance)
                .NotEmpty().WithMessage("IsForMaintenance is required.");
        }
    }

    /// <summary>
    /// Handles the <see cref="LoginUserCommand"/> by authenticating the user against Auth0 and returning user and token information.
    /// </summary>
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDTO?>
    {
        private readonly IAuth0PasswordGrantService passwordGrant;
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginUserCommandHandler"/> class.
        /// </summary>
        /// <param name="passwordGrant">Service for performing password grant authentication against Auth0.</param>
        /// <param name="userRepository">Repository for querying user data in the system.</param>
        public LoginUserCommandHandler(IAuth0PasswordGrantService passwordGrant, IUserRepository userRepository)
        {
            this.passwordGrant = passwordGrant;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Handles the <see cref="LoginUserCommand"/> by performing authentication and returning a <see cref="LoginResponseDTO"/> with tokens and user details.
        /// </summary>
        /// <param name="request">The command containing the user's login credentials.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="LoginResponseDTO"/> containing access, refresh, and ID tokens, as well as user information.</returns>
        /// <exception cref="AuthenticationFailedException">Thrown when authentication fails due to invalid credentials or account status.</exception>
        /// <exception cref="NotFoundException">Thrown when the user exists in Auth0 but not in the local system database.</exception>
        public async Task<LoginResponseDTO?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {

            TokenResponseDTO? tokens = await passwordGrant.LoginAsync(request.Email, request.Password);

            if (tokens == null)
                throw new AuthenticationFailedException(message: "Invalid email or password.", errorCode: "INVALID_CREDENTIALS");

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwt = handler.ReadJwtToken(tokens.id_token);
            string auth0UserId = jwt.Claims.First(c => c.Type == "sub").Value;

            Domain.User? user = await userRepository.GetUserByAuth0IdIncludingDeleted(auth0UserId);

            if (user == null)
                throw new NotFoundException("User account does not exist in the system.");

            if (user.IsDeleted && user.IsApproved)
                throw new AuthenticationFailedException("User account has been deleted.", "USER_DELETED");

            if (user.IsDeleted && !user.IsApproved)
                throw new AuthenticationFailedException("User account has been rejected.", "USER_REJECTED");

            if (!user.IsApproved && !user.IsDeleted)
                throw new AuthenticationFailedException("User account is not approved.", "NOT_APPROVED");

            if (request.IsForMaintenance == true && user.Role == UserRole.Operator)
                throw new AuthenticationFailedException("User does not have access to the maintenance app.", "UNAUTHORIZED_ACCESS_MAINTENANCE");

            if (request.IsForMaintenance == false && (user.Role == UserRole.Admin || user.Role == UserRole.Manager))
                throw new AuthenticationFailedException("User does not have access to the operators app.", "UNAUTHORIZED_ACCESS_USER");

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
