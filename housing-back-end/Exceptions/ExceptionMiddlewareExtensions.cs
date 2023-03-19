using System.Net;
using housing_back_end.Middlewares;
using Microsoft.AspNetCore.Diagnostics;

namespace housing_back_end.Exceptions;

public static class ExceptionMiddlewareExtensions
{

    public static void ConfigureExceptionHandler(this IApplicationBuilder app, 
        IWebHostEnvironment env)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
    public static void ConfigureBuiltinExceptionHandler(this IApplicationBuilder app, 
        IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler(
                options => {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            if (ex != null)
                            {
                                await context.Response.WriteAsync(ex.Error.Message);
                            }
                        }
                    ); 
                }
            );
        }
    }
}