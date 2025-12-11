using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    /// <summary>
    /// Represents a query to retrieve a paged list of all approved users with optional search functionality.
    /// </summary>
    public class GetAllApprovedUsersPagedQuery: IRequest<PagedResponseDto<UserDto>>
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
        /// The search string used to filter users.
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// Column to sort by: "FirstName", "PhoneNumber", "Email o" or Role
        /// </summary>
        public string? SortBy { get; set; } = "FirstName";

        /// <summary>
        /// Sort direction: "asc" or "desc"
        /// </summary>
        public string? SortDirection { get; set; } = "asc";
    }

    /// <summary>
    /// Handles the <see cref="GetAllApprovedUsersPagedQuery"/> by retrieving a paged list of users from the repository,
    /// mapping them to <see cref="UserDto"/>.
    /// </summary>
    public class GetAllUsersPagedQueryHandler : IRequestHandler<GetAllApprovedUsersPagedQuery, PagedResponseDto<UserDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUsersPagedQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetAllUsersPagedQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetAllApprovedUsersPagedQuery"/> by fetching the requested page of users,
        /// mapping them to <see cref="UserDto"/>, and returning a paged response.
        /// </summary>
        /// <param name="request">The query containing page number, page size, and search string.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="PagedResponse{UserDTO}"/> containing the paged list of users.</returns>
        public async Task<PagedResponseDto<UserDto>> Handle(GetAllApprovedUsersPagedQuery request, CancellationToken cancellationToken)
        {
            if (request.Search == null) request.Search = "";

            (IEnumerable<Domain.User> items, int totalCount) = await uow.UserRepository.GetAllApprovedPaged(request.PageNr, request.PageSize, request.Search, request.SortBy, request.SortDirection);

            IEnumerable<UserDto> users = mapper.Map<IEnumerable<UserDto>>(items);

            return new PagedResponseDto<UserDto>
            {
                Items = users,
                PageNumber = request.PageNr,
                PageSize = request.PageSize,
                TotalItems = totalCount
            };
        }
    }
}
