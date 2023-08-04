using Newtonsoft.Json;
using Utils.Exceptions;

namespace WebApp.Extensions
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException customException)
            {
                context.Response.StatusCode = customException.StatusCode;

                var errorResponse = new
                {
                    StatusCode = customException.StatusCode,
                    Message = customException.ErrorMessage
                };

                var jsonResponse = JsonConvert.SerializeObject(errorResponse);
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(jsonResponse);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                var errorResponse = new
                {
                    StatusCode = 500,
                    Message = ex.Message
                };

                var jsonResponse = JsonConvert.SerializeObject(errorResponse);
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
