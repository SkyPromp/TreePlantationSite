namespace AP.BTP.Application.CQRS.Auth0User
{
    /// <summary>
    /// Represents the data required to approve a user and assign a role.
    /// </summary>
    public class ApproveUserDTO
    {
        public required string Role { get; set; }
    }
}
