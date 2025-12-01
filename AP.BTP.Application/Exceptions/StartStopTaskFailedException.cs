namespace AP.BTP.Application.Exceptions
{
    /// <summary>
    /// Represents an exception thrown when a task cannot be started or stoped.
    /// </summary>
    public class StartStopTaskFailedException : Exception
    {
        /// <summary>
        /// Gets the specific error code associated with the exception.
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationFailedException"/> class with a specified error message and code.
        /// </summary>
        /// <param name="message">The message describing the reason for the exception.</param>
        /// <param name="errorCode">A string representing the specific error code for the exception.</param>
        public StartStopTaskFailedException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
