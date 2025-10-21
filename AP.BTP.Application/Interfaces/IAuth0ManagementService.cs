using AP.BTP.Application.CQRS.Users;
using System.Text.Json;

namespace AP.BTP.Application.Interfaces
{
    public interface IAuth0ManagementService
    {
        Task<string> GetManagementTokenAsync();
        Task ApproveUserAsync(string userId);
        Task<List<Auth0User>> ListUnapprovedUsersAsync();
    }
}
