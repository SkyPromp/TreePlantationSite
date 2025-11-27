namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a standardized JSON error response returned by <see cref="ExceptionHandlingMiddleware"/>.
    /// </summary>
    public class ErrorResponseInfoDTO
    {
        /// <summary>
        /// Gets or sets the HTTP status code of the error response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error message describing the problem.
        /// </summary>
        public string Message { get; set; }  // TODO read warning

        /// <summary>
        /// Gets or sets the error code associated with the current operation.
        /// </summary>
        public string ErrorCode { get; set; }
    }
}
