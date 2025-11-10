using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using MediatR;

namespace AP.BTP.Application.CQRS.Auth0User
{
    /// <summary>
    /// Represents a query to retrieve all roles from Auth0.
    /// </summary>
    public class GetAllRolesQuery : IRequest<IEnumerable<Auth0RoleDTO>>
    {
    }

    /// <summary>
    /// Handles the <see cref="GetAllRolesQuery"/> by retrieving all roles from the Auth0 management service.
    /// </summary>
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<Auth0Role>>
    {
        private readonly IAuth0ManagementService _auth0;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllRolesQueryHandler"/> class.
        /// </summary>
        /// <param name="auth0">The Auth0 management service used to retrieve role data.</param>
        public GetAllRolesQueryHandler(IAuth0ManagementService auth0)
        {
            _auth0 = auth0;
        }

        /// <summary>
        /// Handles the <see cref="GetAllRolesQuery"/> by calling the Auth0 API to obtain all available roles.
        /// </summary>
        /// <param name="request">The query request (contains no parameters).</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A collection of <see cref="Auth0Role"/> objects retrieved from Auth0.</returns>
        public async Task<IEnumerable<Auth0RoleDTO>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await _auth0.GetRoles();
        }
    }
}
