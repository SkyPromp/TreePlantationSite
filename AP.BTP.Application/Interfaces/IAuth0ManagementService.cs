using AP.BTP.Contracts.DTOs;

namespace AP.BTP.Application.Interfaces
{
    public interface IAuth0ManagementService
    {
        Task ApproveUserAsync(string userId, string role);
        Task<(IEnumerable<Auth0User> Items, int TotalCount)> GetAllUnapprovedUsersPaged(int pageNr, int pageSize, string search);
        Task<IEnumerable<Auth0Role>> GetRoles();
    }
}
