using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    public class GetAllTreeQuery: IRequest<IEnumerable<TreeDTO>>
    {
    }

    public class GetAllTreeQueryValidator: AbstractValidator<GetAllTreeQuery>
    {
        public GetAllTreeQueryValidator(IUnitOfWork uow)
        {
        }
    }

    public class GetAllTreeQueryHandler: IRequestHandler<GetAllTreeQuery, IEnumerable<TreeDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllTreeQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<TreeDTO>> Handle(GetAllTreeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Tree> trees = await uow.TreeRepository.GetAll();

            IEnumerable<TreeDTO> treeDTOs = mapper.Map<IEnumerable<TreeDTO>>(trees);

            return treeDTOs;
        }
    }
}
