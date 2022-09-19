using PagosPruebaTuya.Common.Handler;
using PagosPruebaTuya.Common.Utils;
using PagosPruebaTuya.Dto.Config.Common;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace PagosPruebaTuya.API.App_Start
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ExceptionHandle exceptionHandle)
        {
            app.UseExceptionHandler(appError =>
                 {
                     appError.Run(async context =>
                    {
                        context.Response.ContentType = "application/json";
                        IExceptionHandlerFeature? contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                        HttpResponseErrorDto httpResponseErrorDto = exceptionHandle.GenerateException(contextFeature.Error);
                        HttpStatusCode code = HttpStatusCode.InternalServerError;
                        if (Enum.IsDefined(typeof(HttpStatusCode), contextFeature.Error.HResult)) code = (HttpStatusCode)contextFeature.Error.HResult;
                        context.Response.StatusCode = (int)code;
                        await context.Response.WriteAsync(httpResponseErrorDto.Serialize());
                    });
                 });
        }
    }
}
