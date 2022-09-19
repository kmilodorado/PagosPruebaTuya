namespace PagosPruebaTuya.API.App_Start
{
    public static class NetCoreConfig
    {
        public static void RegisterNetCoreConfig(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
            services.AddOptions();
            services.AddHttpClient();
        }
    }
}
