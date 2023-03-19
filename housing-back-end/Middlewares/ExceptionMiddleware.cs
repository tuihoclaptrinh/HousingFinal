using System.Net;
using housing_back_end.Errors;

namespace housing_back_end.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next,
        ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env)
    {
        this._env = env;
        this._next = next;
        this._logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            ApiError response;
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            String message;
            var exceptionType = ex.GetType();

            if(exceptionType == typeof(UnauthorizedAccessException))
            {
                statusCode = HttpStatusCode.Forbidden;
                message = "You are not authorized";
            } else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = "Some unknown error occurred";
            }

            if(_env.IsDevelopment())
            {
                response = new ApiError((int)statusCode,ex.Message,ex.StackTrace.ToString());
            } else {
                response = new ApiError((int)statusCode,message);
            }

            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType="application/json";
            await context.Response.WriteAsync(response.ToString());
        }
    }
}