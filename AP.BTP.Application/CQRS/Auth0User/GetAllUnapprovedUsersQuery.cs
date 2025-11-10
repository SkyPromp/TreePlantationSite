using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    /// <summary>
    /// Represents a query to retrieve a paged list of unapproved users from Auth0, optionally filtered by a search term.
    /// </summary>
    public class GetAllUnapprovedUsersPagedQuery() : IRequest<PagedResponseDTO<Auth0UserDTO>>
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
    /// Handles the <see cref="GetAllUnapprovedUsersPagedQuery"/> by retrieving a paged collection of unapproved Auth0 users.
    /// </summary>
    public class GetAllUnapprovedUsersPagedQueryHandler : IRequestHandler<GetAllUnapprovedUsersPagedQuery, PagedResponseDTO<Auth0UserDTO>>
    {
        private readonly IAuth0ManagementService _auth0;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUnapprovedUsersPagedQueryHandler"/> class.
        /// </summary>
        /// <param name="auth0">The Auth0 management service used to retrieve unapproved user data.</param>
        public GetAllUnapprovedUsersPagedQueryHandler(IAuth0ManagementService auth0)
        {
            _auth0 = auth0;
        }

        /// <summary>
        /// Handles the <see cref="GetAllUnapprovedUsersPagedQuery"/> by retrieving a paged list of unapproved users from Auth0.
        /// </summary>
        /// <param name="request">The query containing pagination parameters and an optional search term.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="PagedResponse{T}"/> containing the unapproved users for the requested page and the total user count.
        /// </returns>
        public async Task<PagedResponseDTO<Auth0UserDTO>> Handle(GetAllUnapprovedUsersPagedQuery request, CancellationToken cancellationToken)
        {
            (IEnumerable<Auth0UserDTO> items, int totalCount) = await _auth0.GetAllUnapprovedUsersPaged(request.PageNr, request.PageSize, request.Search);

            return new PagedResponseDTO<Auth0UserDTO>
            {
                Items = items,
                PageNumber = request.PageNr,
                PageSize = request.PageSize,
                TotalItems = totalCount
            };
        }
    }
}
