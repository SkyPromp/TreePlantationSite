using AP.BTP.Application.Interfaces;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    public class GetAllRolesQuery : IRequest<IEnumerable<Auth0Role>>
    {
    }

    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<Auth0Role>>
    {
        private readonly IAuth0ManagementService _auth0;

        public GetAllRolesQueryHandler(IAuth0ManagementService auth0)
        {
            _auth0 = auth0;
        }

        public async Task<IEnumerable<Auth0Role>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await _auth0.GetRoles();
        }
    }
}
