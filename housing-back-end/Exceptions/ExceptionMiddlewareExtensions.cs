using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace housing_back_end.Exceptions;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        app.UseExceptionHandler(options =>
        {
            options.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var ex = context.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {
                    await context.Response.WriteAsync(ex.Error.Message);
                }
            });
        });

        return app;
    }
}