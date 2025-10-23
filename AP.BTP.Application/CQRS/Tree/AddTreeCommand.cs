using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    public class AddTreeCommand: IRequest<TreeDTO>
    {
        public required TreeDTO Tree { get; set; }
    }

    public class AddTreeCommandValidator: AbstractValidator<AddTreeCommand>
    {
        public AddTreeCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Tree.Species)
                .NotEmpty()
                .WithMessage("Species name is required.");

            RuleFor(command => command.Tree.Id)
                .Equal(0)
                .WithMessage("Id should be zero when adding a tree.");
        }
    }

    public class AddTreeCommandHandler: IRequestHandler<AddTreeCommand, TreeDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddTreeCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        public async Task<TreeDTO> Handle(AddTreeCommand request, CancellationToken cancellationToken)
        {
            Domain.Tree tree = mapper.Map<Domain.Tree>(request.Tree);

            await uow.TreeRepository.Create(tree);
            await uow.Commit();

            return mapper.Map<TreeDTO>(tree);
        }
    }
}
