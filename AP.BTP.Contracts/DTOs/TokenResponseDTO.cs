namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a data transfer object (DTO) containing tokens returned by Auth0 after authentication.
    /// </summary>
    public class TokenResponseDTO
    {
        /// <summary>
        /// The access token issued by Auth0 to access protected resources.
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// The refresh token issued by Auth0, used to obtain a new access token when the current one expires.
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// The ID token issued by Auth0 containing user identity claims in JWT format.
        /// </summary>
        public string id_token { get; set; }

        /// <summary>
        /// The type of the token issued.
        /// </summary>
        public string token_type { get; set; }

        /// <summary>
        /// The lifetime of the access token in seconds before it expires.
        /// </summary>
        public int expires_in { get; set; }
    }
}
