namespace AP.BTP.Application.CQRS.Auth0User
{
    /// <summary>
    /// Represents a role definition in Auth0.
    /// </summary>
    /// <param name="Id">The unique identifier of the role.</param>
    /// <param name="Name">The name of the role.</param>
    /// <param name="Description">A brief description of the role's purpose or permissions.</param>
    public record Auth0Role
    (
        string Id,
        string Name,
        string Description
    );
}
