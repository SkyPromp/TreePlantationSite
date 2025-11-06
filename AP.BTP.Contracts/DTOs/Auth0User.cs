using System.Text.Json;

<<<<<<<< HEAD:AP.BTP.Contracts/DTOs/Auth0User.cs
namespace AP.BTP.Contracts.DTOs
|||||||| aff522c:AP.BTP.Application/CQRS/Auth0Users/Auth0User.cs
namespace AP.BTP.Application.CQRS.Users
========
namespace AP.BTP.Application.CQRS.Auth0User
>>>>>>>> eee55fb1b36c608e7f0ed8a191874fbc2702000f:AP.BTP.Application/CQRS/Auth0User/Auth0User.cs
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
