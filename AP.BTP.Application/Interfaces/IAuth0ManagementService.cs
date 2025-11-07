using AP.BTP.Application.CQRS.Auth0User;

namespace AP.BTP.Application.Interfaces
{
    public interface IAuth0ManagementService
    {
        Task ApproveUserAsync(string userId, string role);
        Task<(IEnumerable<Auth0User> Items, int TotalCount)> GetAllUnapprovedUsersPaged(int pageNr, int pageSize, string search);
        Task<IEnumerable<Auth0Role>> GetRoles();
        Task<Auth0User?> GetUserByIdAsync(string auth0Id);
        Task DeleteUserAsync(string userId);
    }
}
