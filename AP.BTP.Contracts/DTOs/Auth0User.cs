using System.Text.Json;

namespace AP.BTP.Contracts.DTOs
{
    public record Auth0User
    (
        string user_id,
        string email,
        string? username,
        DateTime? created_at,
        JsonElement? app_metadata
    );
}
