using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    /// <summary>
    /// Represents a query to retrieve a paged list of unapproved users, optionally filtered by a search term.
    /// </summary>
    public class GetAllUnapprovedUsersPagedQuery() : IRequest<PagedResponseDTO<UserDTO>>
    {
        /// <summary>
        /// The page number to retrieve.
        /// </summary>
        public int PageNr { get; set; }

        /// <summary>
        /// The number of users to include per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The search term used to filter unapproved users.
        /// </summary>
        public string? Search { get; set; }
    }

    /// <summary>
    /// Handles the <see cref="GetAllUnapprovedUsersPagedQuery"/> by retrieving a paged collection of unapproved users.
    /// </summary>
    public class GetAllUnapprovedUsersPagedQueryHandler : IRequestHandler<GetAllUnapprovedUsersPagedQuery, PagedResponseDTO<UserDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUnapprovedUsersPagedQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetAllUnapprovedUsersPagedQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetAllUnapprovedUsersPagedQuery"/> by retrieving a paged list of users.
        /// </summary>
        /// <param name="request">The query containing pagination parameters and an optional search term.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="PagedResponse{T}"/> containing the unapproved users for the requested page and the total user count.
        /// </returns>
        public async Task<PagedResponseDTO<UserDTO>> Handle(GetAllUnapprovedUsersPagedQuery request, CancellationToken cancellationToken)
        {
            if (request.Search == null) request.Search = "";

            (IEnumerable<Domain.User> items, int totalCount) = await uow.UserRepository.GetAllUnapprovedUsersPaged(request.PageNr, request.PageSize, request.Search);

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
