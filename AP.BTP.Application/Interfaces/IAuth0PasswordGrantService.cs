using AP.BTP.Contracts.DTOs;

namespace AP.BTP.Application.Interfaces
{
    /// <summary>
    /// Defines methods for authenticating users via Auth0 using the password grant flow.
    /// </summary>
    public interface IAuth0PasswordGrantService
    {
        /// <summary>
        /// Authenticates a user with Auth0 using their email and password, returning an access token if successful.
        /// </summary>
        /// <param name="email">The email address of the user attempting to log in.</param>
        /// <param name="password">The password of the user attempting to log in.</param>
        /// <returns>
        /// A task that returns a <see cref="TokenResponseDTO"/> containing the access token and related authentication information
        /// if the login is successful; otherwise, null.
        /// </returns>
        Task<TokenResponseDTO?> LoginAsync(string email, string password);
    }
}
