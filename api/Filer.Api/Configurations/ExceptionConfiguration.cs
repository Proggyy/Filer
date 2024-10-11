using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace Filer.Api.Configurations;

public static class ExceptionConfiguration{
    public static void ConfigureExceptionHandler(this WebApplication app){
        app.UseExceptionHandler(builder => {
            builder.Run(async context => {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var feature = context.Features.Get<IExceptionHandlerFeature>();

                if(feature != null)
                {
                    app.Logger.LogError($"Error: {feature.Error}");
                    await context.Response.WriteAsync(new Error{
                        Message = "Server error",
                        StatusCode = context.Response.StatusCode
                    }.ToString());
                }
            });
        });
    }
}

public class Error{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}