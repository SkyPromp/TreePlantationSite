namespace AP.BTP.Application.Exceptions
{
    /// <summary>
    /// Represents an exception thrown when user creation fails.
    /// </summary>
    public class Auth0UserCreationException : Exception
    {
        /// <summary>
        /// Gets the specific error code associated with the user creation failure.
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Auth0UserCreationException"/> class with a specified error message and code.
        /// </summary>
        /// <param name="message">The message describing the reason for the authentication failure.</param>
        /// <param name="errorCode">A string representing the specific error code for the failure.</param>
        public Auth0UserCreationException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
