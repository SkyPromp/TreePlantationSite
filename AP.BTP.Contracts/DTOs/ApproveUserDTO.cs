namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents the data required to approve a user and assign a role.
    /// </summary>
    public record ApproveUserDTO
    {
        /// <summary>
        /// The role to be assigned to the user upon approval.
        /// </summary>
        public required string Role { get; set; }
    }
}
