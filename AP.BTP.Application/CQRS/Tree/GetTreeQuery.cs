using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    /// <summary>
    /// Represents a query to retrieve a paged list of trees with optional search functionality.
    /// </summary>
    public class GetTreeQuery: IRequest<Paged<TreeDTO>>
    {
        /// <summary>
        /// The page number to retrieve.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The number of items per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// An optional search string to filter trees by relevant fields (e.g., species name).
        /// </summary>
        public string? SearchString { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetTreeQuery"/>.
    /// Currently no specific validation rules are applied, but the class is available for future validation needs.
    /// </summary>
    public class GetTreeQueryValidator: AbstractValidator<GetTreeQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTreeQueryValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public GetTreeQueryValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="GetTreeQuery"/> by retrieving a paged list of trees from the repository, optionally filtered by a search string, and mapping them to <see cref="TreeDTO"/> objects.
    /// </summary>
    public class GetTreeQueryHandler: IRequestHandler<GetTreeQuery, Paged<TreeDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTreeQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetTreeQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetTreeQuery"/> by fetching the requested page of trees, mapping them to <see cref="TreeDTO"/>, and returning a <see cref="Paged{TreeDTO}"/> result.
        /// </summary>
        /// <param name="request">The query containing the page number, page size, and optional search string.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Paged{TreeDTO}"/> object containing the requested page of trees.</returns>
        public async Task<Paged<TreeDTO>> Handle(GetTreeQuery request, CancellationToken cancellationToken)
        {
            Paged<Domain.Tree> trees = await uow.TreeRepository.GetAll(pageNr:request.Page, pageSize:request.PageSize, search:request.SearchString);

            IEnumerable<TreeDTO> treeDTOs = mapper.Map<IEnumerable<TreeDTO>>(trees.Data);

            return new Paged<TreeDTO>() { PageNr = trees.PageNr, PageSize = trees.PageSize, PageCount = trees.PageCount, Data = treeDTOs };
        }
    }
}
