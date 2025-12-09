using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    /// <summary>
    /// Represents a query to retrieve a paged list of operators with optional search functionality.
    /// </summary>
    public class GetAllOperatorsPagedQuery : IRequest<PagedResponseDTO<UserDTO>>
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
        /// The search string used to filter operators.
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// Column to sort by: "FirstName", "PhoneNumber", or "Email"
        /// </summary>
        public string? SortBy { get; set; } = "FirstName";

        /// <summary>
        /// Sort direction: "asc" or "desc"
        /// </summary>
        public string? SortDirection { get; set; } = "asc";
    }

    /// <summary>
    /// Handles the <see cref="GetAllOperatorsPagedQuery"/> by retrieving a paged list of operators from the repository,
    /// mapping them to <see cref="UserDTO"/>, and enriching each user with Auth0 information.
    /// </summary>
    public class GetAllOperatorsPagedQueryHandler : IRequestHandler<GetAllOperatorsPagedQuery, PagedResponseDTO<UserDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IAuth0ManagementService auth0;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllOperatorsPagedQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        /// <param name="auth0">The Auth0 management service used to enrich user information.</param>
        public GetAllOperatorsPagedQueryHandler(IUnitOfWork uow, IMapper mapper, IAuth0ManagementService auth0)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.auth0 = auth0;
        }

        /// <summary>
        /// Handles the <see cref="GetAllOperatorsPagedQuery"/> by fetching the requested page of operators,
        /// mapping them to <see cref="UserDTO"/>, retrieving additional Auth0 information for each user, and returning a paged response.
        /// </summary>
        /// <param name="request">The query containing page number, page size, and search string.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="PagedResponse{UserDTO}"/> containing the paged list of operators with enriched Auth0 information.</returns>
        public async Task<PagedResponseDTO<UserDTO>> Handle(GetAllOperatorsPagedQuery request, CancellationToken cancellationToken)
        {
            if (request.Search == null) request.Search = "";

            (IEnumerable<Domain.User> items, int totalCount) = await uow.UserRepository.GetAllOperatorsPaged(request.PageNr, request.PageSize, request.Search, request.SortBy, request.SortDirection);

            IEnumerable<UserDTO> users = mapper.Map<IEnumerable<UserDTO>>(items);

            return new PagedResponseDTO<UserDTO>
            {
                Items = users,
                PageNumber = request.PageNr,
                PageSize = request.PageSize,
                TotalItems = totalCount
            };
        }
    }
}
