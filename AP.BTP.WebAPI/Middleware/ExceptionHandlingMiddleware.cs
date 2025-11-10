using System.Text.Json;
using FluentValidation;

namespace AP.BTP.WebAPI.Middleware
{
    /// <summary>
    /// Middleware that globally handles exceptions thrown during HTTP request processing.
    /// Converts exceptions into standardized JSON error responses.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middleware in the request pipeline.</param>
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the middleware to handle the current HTTP context.
        /// Catches exceptions, sets the appropriate status code, and writes a JSON error response.
        /// </summary>
        /// <param name="context">The current <see cref="HttpContext"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ErrorResponseInfo response = new ErrorResponseInfo();
                response.Message = ex.Message;
                switch (ex)
                {
                    case ValidationException validationException:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        response.Message = validationException.Message;
                        Console.WriteLine(response.Message);

                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;

                        break;
                }
                context.Response.StatusCode = response.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }

    /// <summary>
    /// Represents a standardized JSON error response returned by <see cref="ExceptionHandlingMiddleware"/>.
    /// </summary>
    public class ErrorResponseInfo
    {
        /// <summary>
        /// Gets or sets the HTTP status code of the error response.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error message describing the problem.
        /// </summary>
        public string Message { get; set; }  // TODO read warning
    }
}
