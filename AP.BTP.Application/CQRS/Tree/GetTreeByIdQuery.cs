using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    public class GetTreeByIdQuery: IRequest<TreeDTO>
    {
        public int Id { get; set; }
    }

    public class GetTreeByIdQueryValidator: AbstractValidator<GetTreeByIdQuery>
    {
        public GetTreeByIdQueryValidator(IUnitOfWork uow)
        {
        }
    }

    public class GetTreeByIdQueryHandler: IRequestHandler<GetTreeByIdQuery, TreeDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetTreeByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<TreeDTO> Handle(GetTreeByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Tree? tree = await uow.TreeRepository.GetById(id:request.Id);
            TreeDTO treeDTO = mapper.Map<TreeDTO>(tree);

            return treeDTO;
        }
    }
}
