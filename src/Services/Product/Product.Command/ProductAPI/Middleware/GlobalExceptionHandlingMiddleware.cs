using System.Net;
using System.Text;

namespace ProductAPI.Middleware
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger) =>
            _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                // Read the request body
                string? requestBody = await ReadRequestBody(context.Request);

                _logger.LogInformation("Information: Request => HTTP {RequestMethod}, {RequestPath}, {RequestBody}, {DateTimeUtc}",
                    context.Request.Method,
                    context.Request.Path,
                    requestBody,
                    DateTime.UtcNow);

                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: {Message}, {InnerException}, {Exception}",
                    ex.Message,
                    ex.InnerException,
                    ex);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            }
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                string requestBody = await reader.ReadToEndAsync();

                // Reset the position of the request body stream so it can be read again
                request.Body.Position = 0;

                return requestBody;
            }
        }
    }
}
