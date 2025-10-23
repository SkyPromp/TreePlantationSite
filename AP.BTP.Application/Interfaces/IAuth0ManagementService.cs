using AP.BTP.Application.CQRS.Users;

namespace AP.BTP.Application.Interfaces
{
    public interface IAuth0ManagementService
    {
        Task<string> GetManagementTokenAsync();
        Task ApproveUserAsync(string userId);
        Task<(IEnumerable<Auth0User> Items, int TotalCount)> GetAllUnapprovedUsersPaged(int pageNr, int pageSize, string search);
    }
}
