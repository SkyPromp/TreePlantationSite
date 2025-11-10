using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    public class GetAllUnapprovedUsersPagedQuery() : IRequest<PagedResponseDTO<Auth0UserDTO>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
        public required string Search { get; set; }
    }

    public class GetAllUnapprovedUsersPagedQueryHandler : IRequestHandler<GetAllUnapprovedUsersPagedQuery, PagedResponseDTO<Auth0UserDTO>>
    {
        private readonly IAuth0ManagementService _auth0;

        public GetAllUnapprovedUsersPagedQueryHandler(IAuth0ManagementService auth0)
        {
            _auth0 = auth0;
        }

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
