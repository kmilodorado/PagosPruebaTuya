using PagosPruebaTuya.Common.ValidateModel;
using Microsoft.AspNetCore.Mvc;

namespace PagosPruebaTuya.API.App_Start
{
    public static class FiltersConfig
    {
        public static void RegisterFiltersConfig(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opts => opts.SuppressModelStateInvalidFilter = true);
            services.AddMvc(options => { options.Filters.Add(new ValidateModelAttribute()); });
        }
    }
}
