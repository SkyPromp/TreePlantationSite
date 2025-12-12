using System.Text.Json;

namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a user record stored in Auth0.
    /// </summary>
    /// <param name="user_id">The unique identifier of the user in Auth0.</param>
    /// <param name="email">The user's email address.</param>
    /// <param name="username">The user's username, if available.</param>
    /// <param name="created_at">The date and time the user account was created.</param>
    /// <param name="app_metadata">Additional metadata associated with the user, stored as a JSON element.</param>
    public record Auth0UserDto
    (
        string user_id,
        string email,
        string? username,
        DateTime? created_at,
        JsonElement? app_metadata
    );
}
