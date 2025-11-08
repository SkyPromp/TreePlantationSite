using System.Text.Json;
using FluentValidation;

namespace AP.BTP.WebAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

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

    public class ErrorResponseInfo
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
