using AP.BTP.Contracts.DTOs;

namespace AP.BTP.Application.Interfaces
{
    public interface IAuth0ManagementService
    {
        Task ApproveUserAsync(string userId, string role);
        Task<(IEnumerable<Auth0UserDTO> Items, int TotalCount)> GetAllUnapprovedUsersPaged(int pageNr, int pageSize, string search);
        Task<IEnumerable<Auth0RoleDTO>> GetRoles();
        Task<Auth0UserDTO?> GetUserByIdAsync(string auth0Id);
        Task DeleteUserAsync(string userId);
    }
}
