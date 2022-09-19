using PagosPruebaTuya.Common.Enviroments;
using Microsoft.OpenApi.Models;

namespace PagosPruebaTuya.API.App_Start
{
    public static class SwaggerConfig
    {
        public static void RegisterSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = Variables.Swagger.SW_VERSION,
                    Title = Variables.Swagger.SW_TITLE,
                    Description = Variables.Swagger.SW_DESCRIPTION,
                    Contact= new OpenApiContact()
                    {
                        Name= Variables.Swagger.SW_NAME,
                        Email= Variables.Swagger.SW_EMAIL,
                        Url= null,
                    }
                });
            });
        }

        public static void ConfigureSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: Variables.Swagger.SW_URL_JSON, name: Variables.Swagger.SW_TITLE);
            });
        }
    }
}
