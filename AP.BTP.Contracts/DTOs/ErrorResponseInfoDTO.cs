namespace AP.BTP.Contracts.DTOs
{
    /// <summary>
    /// Represents a standardized JSON error response returned by <see cref="ExceptionHandlingMiddleware"/>.
    /// </summary>
    public record ErrorResponseInfoDto
    {
        /// <summary>
        /// Gets or sets the HTTP status code of the error response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error message describing the problem.
        /// </summary>
        public required string Message { get; set; }

        /// <summary>
        /// Gets or sets the error code associated with the current operation.
        /// </summary>
        public required string ErrorCode { get; set; }
    }
}
