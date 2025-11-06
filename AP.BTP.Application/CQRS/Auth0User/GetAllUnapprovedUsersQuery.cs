using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    public class GetAllUnapprovedUsersPagedQuery() : IRequest<PagedResponseDTO<Auth0User>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
        public required string Search { get; set; }
    }

    public class GetAllUnapprovedUsersPagedQueryHandler : IRequestHandler<GetAllUnapprovedUsersPagedQuery, PagedResponseDTO<Auth0User>>
    {
        private readonly IAuth0ManagementService _auth0;

        public GetAllUnapprovedUsersPagedQueryHandler(IAuth0ManagementService auth0)
        {
            _auth0 = auth0;
        }

        public async Task<PagedResponseDTO<Auth0User>> Handle(GetAllUnapprovedUsersPagedQuery request, CancellationToken cancellationToken)
        {
            (IEnumerable<Auth0User> items, int totalCount) = await _auth0.GetAllUnapprovedUsersPaged(request.PageNr, request.PageSize, request.Search);

            return new PagedResponseDTO<Auth0User>
            {
                Items = items,
                PageNumber = request.PageNr,
                PageSize = request.PageSize,
                TotalItems = totalCount
            };
        }
    }
}
