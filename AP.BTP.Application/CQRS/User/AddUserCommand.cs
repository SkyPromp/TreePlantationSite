using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    /// <summary>
    /// Represents a command to register a new user in the system.
    /// </summary>
    public class AddUserCommand : IRequest<UserDto>
    {
        /// <summary>
        /// The data transfer object containing the details of the user to register.
        /// </summary>
        public required RegisterUserDto User { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="AddUserCommand"/>.
    /// </summary>
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator(IUnitOfWork uow)
        {
            RuleFor(x => x.User.FirstName)
                .NotEmpty()
                .WithMessage("Voornaam is verplicht.");

            RuleFor(x => x.User.LastName)
                .NotEmpty()
                .WithMessage("Achternaam is verplicht.");

            RuleFor(x => x.User.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Ongeldig e-mailadres.");

            RuleFor(x => x.User.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\+?[0-9\s\-]{7,15}$")
                .WithMessage("Ongeldig telefoonnummer.");

            RuleFor(x => x.User.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches(@"[A-Z]+").WithMessage("Wachtwoord moet minimaal 1 hoofdletter bevatten.")
                .Matches(@"[a-z]+").WithMessage("Wachtwoord moet minimaal 1 kleine letter bevatten.")
                .Matches(@"\d+").WithMessage("Wachtwoord moet minimaal 1 nummer bevatten.")
                .Matches(@"[\W_]+").WithMessage("Wachtwoord moet minimaal 1 speciaal teken bevatten.");

            RuleFor(x => x.User.ConfirmPassword)
                .Equal(x => x.User.Password)
                .WithMessage("Wachtwoorden komen niet overeen.");

            RuleFor(x => x.User.Email)
                .MustAsync(async (email, cancellation) =>
                    await uow.UserRepository.IsEmailUnique(email))
                .WithMessage("E-mailadres is al in gebruik.");

            RuleFor(x => x)
                .MustAsync(async (command, cancellation) =>
                    await uow.UserRepository.IsFullNameUnique(
                        command.User.FirstName,
                        command.User.LastName))
                .WithMessage("Een gebruiker met deze voornaam en achternaam bestaat al.");
        }
    }

    /// <summary>
    /// Handles the <see cref="AddUserCommand"/> by registering a new user in the system.
    /// </summary>
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserDto>
    {
        private readonly IAuth0ManagementService auth0;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddUserCommandHandler(IAuth0ManagementService auth0, IUnitOfWork uow, IMapper mapper)
        {
            this.auth0 = auth0;
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<UserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            Auth0UserDto auth0User = await auth0.CreateUserAsync(request.User.FirstName, request.User.Email, request.User.Password);

            Domain.User userEntity = mapper.Map<Domain.User>(request.User);

            userEntity.Auth0Id = auth0User.user_id;

            await uow.UserRepository.Create(userEntity);
            await uow.Commit();

            return mapper.Map<UserDto>(userEntity);
        }
    }
}
