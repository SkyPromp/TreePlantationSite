using System.Text.Json;
using AP.BTP.Application.Exceptions;
using AP.BTP.Contracts.DTOs;
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
                ErrorResponseInfoDto response = ex switch
                {
                    ValidationException validationException => new ErrorResponseInfoDto
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = validationException.Message,
                        ErrorCode = "VALIDATION_ERROR"
                    },
                    Auth0UserCreationException auth0UserCreationException => new ErrorResponseInfoDto
                    {
                        StatusCode = auth0UserCreationException.ErrorCode switch
                        {
                            "USER_ALREADY_EXISTS" => StatusCodes.Status409Conflict,
                            "AUTH0_EMPTY_RESPONSE" => StatusCodes.Status502BadGateway,
                            "AUTH0_USER_CREATION_FAILED" => StatusCodes.Status502BadGateway,
                            _ => StatusCodes.Status500InternalServerError
                        },
                        Message = auth0UserCreationException.Message,
                        ErrorCode = auth0UserCreationException.ErrorCode
                    },
                    AuthenticationFailedException authenticationFailedException => new ErrorResponseInfoDto
                    {
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Message = authenticationFailedException.Message,
                        ErrorCode = authenticationFailedException.ErrorCode
                    },
                    StartStopTaskFailedException startStopTaskFailedException => new ErrorResponseInfoDto
                    {
                        StatusCode = StatusCodes.Status409Conflict,
                        Message = startStopTaskFailedException.Message,
                        ErrorCode = startStopTaskFailedException.ErrorCode
                    },
                    NotFoundException notFoundException => new ErrorResponseInfoDto
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = notFoundException.Message,
                        ErrorCode = "NOT_FOUND"
                    },
                    _ => new ErrorResponseInfoDto
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = ex.Message,
                        ErrorCode = "INTERNAL_ERROR"
                    }
                };
                context.Response.StatusCode = response.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
