using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    public class EditTreeCommand: IRequest<TreeDTO>
    {
        public TreeDTO Tree { get; set; }
    }

    public class EditTreeCommandValidator: AbstractValidator<EditTreeCommand>
    {
        public EditTreeCommandValidator(IUnitOfWork uow)
        {
            RuleFor(command => command.Tree.Species)
                .NotEmpty()
                .WithMessage("Species name is required.");

            RuleFor(command => command.Tree.Id)
                .NotEqual(0)
                .WithMessage("Id should not be zero when editing a tree.");
        }
    }

    public class EditTreeCommandHandler: IRequestHandler<EditTreeCommand, TreeDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public EditTreeCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        public async Task<TreeDTO> Handle(EditTreeCommand request, CancellationToken cancellationToken)
        {
            Domain.Tree tree = mapper.Map<Domain.Tree>(request.Tree);

            uow.TreeRepository.Update(tree);
            await uow.Commit();

            return request.Tree;
        }
    }
}
