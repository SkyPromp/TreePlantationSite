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
    public class GetAllTreesPagedQuery: IRequest<PagedResponseDTO<TreeDTO>>
    {
        /// <summary>
        /// The page number to retrieve.
        /// </summary>
        public int PageNr { get; set; }

        /// <summary>
        /// The number of items per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// An optional search string to filter trees by relevant fields (e.g., species name).
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// An optional sorting bool to sort trees by species. Defaults to sort ascending.
        /// </summary>
        public bool SortAscending { get; set; } = true;
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetAllTreesPagedQuery"/>.
    /// Currently no specific validation rules are applied, but the class is available for future validation needs.
    /// </summary>
    public class GetAllTreesPagedQueryValidator: AbstractValidator<GetAllTreesPagedQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTreesPagedQueryValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public GetAllTreesPagedQueryValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="GetAllTreesPagedQuery"/> by retrieving a paged list of trees from the repository, optionally filtered by a search string, and mapping them to <see cref="TreeDTO"/> objects.
    /// </summary>
    public class GetAllTreesPagedQueryHandler: IRequestHandler<GetAllTreesPagedQuery, PagedResponseDTO<TreeDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTreesPagedQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetAllTreesPagedQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetAllTreesPagedQuery"/> by fetching the requested page of trees, mapping them to <see cref="TreeDTO"/>, and returning a <see cref="Paged{TreeDTO}"/> result.
        /// </summary>
        /// <param name="request">The query containing the page number, page size, and optional search string.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="PagedResponseDTO{TreeDTO}"/> object containing the requested page of trees.</returns>
        public async Task<PagedResponseDTO<TreeDTO>> Handle(GetAllTreesPagedQuery request, CancellationToken cancellationToken)
        {
            (IEnumerable<Domain.Tree> items, int totalCount) = await uow.TreeRepository.GetAllPaged(request.PageNr, request.PageSize, request.Search, request.SortAscending);

            return new PagedResponseDTO<TreeDTO>
            {
                Items = mapper.Map<IEnumerable<TreeDTO>>(items),
                PageNumber = request.PageNr,
                PageSize = request.PageSize,
                TotalItems = totalCount
            };
        }
    }
}
