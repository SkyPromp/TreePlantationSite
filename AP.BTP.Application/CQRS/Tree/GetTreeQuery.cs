using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    public class GetTreeQuery: IRequest<Paged<TreeDTO>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
    }

    public class GetTreeQueryValidator: AbstractValidator<GetTreeQuery>
    {
        public GetTreeQueryValidator(IUnitOfWork uow)
        {
        }
    }

    public class GetTreeQueryHandler: IRequestHandler<GetTreeQuery, Paged<TreeDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetTreeQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        public async Task<Paged<TreeDTO>> Handle(GetTreeQuery request, CancellationToken cancellationToken)
        {
            await uow.TreeRepository.GetAll(tree);

            return new Paged<TreeDTO>() { PageNr = request.Page, PageSize = request.PageSize, PageCount =, Data = };
        }
    }
}
