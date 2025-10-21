using AP.BTP.Application.Interfaces;
using MediatR;

namespace AP.BTP.Application.CQRS.Users
{
    public class GetAllUnapprovedUsersQuery() : IRequest<List<Auth0User>>
    {

    }

    public class GetAllUnapprovedUsersQueryHandler : IRequestHandler<GetAllUnapprovedUsersQuery, List<Auth0User>>
    {
        private readonly IAuth0ManagementService _auth0;

        public GetAllUnapprovedUsersQueryHandler(IAuth0ManagementService auth0)
        {
            _auth0 = auth0;
        }

        public async Task<List<Auth0User>> Handle(GetAllUnapprovedUsersQuery request, CancellationToken cancellationToken)
        {
            return await _auth0.ListUnapprovedUsersAsync();
        }
    }
}
