
using OrderManagementSystem.API.Errors;
using System.Text.Json;

namespace OrderManagementSystem.API.MiddleWare
{
    public class ExceptionMiddleWare 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleWare(RequestDelegate next , ILogger<ExceptionMiddleWare> logger , IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
               await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var Response = _env.IsDevelopment() ? new ApiExceptionResponse(StatusCodes.Status500InternalServerError,
                                ex.Message, ex.StackTrace?.ToString()) 
                                    : new ApiExceptionResponse(StatusCodes.Status500InternalServerError);
                var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var JsonResponse = JsonSerializer.Serialize(Response, options);
                await context.Response.WriteAsync(JsonResponse);
            }
        }

    }
}
