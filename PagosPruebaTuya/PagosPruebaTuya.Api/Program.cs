using Microsoft.EntityFrameworkCore;
using PagosPruebaTuya.API.App_Start;
using PagosPruebaTuya.Common.Enviroments;
using PagosPruebaTuya.Data.Models.AplicationDb;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.RegisterDependencyInjectionConfig(Configuration);
builder.Services.RegisterSwaggerConfig();
builder.Services.RegisterNetCoreConfig();
builder.Services.RegisterFiltersConfig();
builder.Services.AddDbContext<AplicationDbContext>(option =>
{
    if (!option.IsConfigured)
    {
        option.UseSqlServer(Variables.Conection.CONNECTIONSTRINSG_TUYAPAGOSPRUEBATECNICA,
       providerOptions =>
       {
           providerOptions.EnableRetryOnFailure();
       });
    }
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AplicationDbContext>();
    context.Database.Migrate();
};
app.UseHttpsRedirection();
app.ConfigureSwaggerConfig();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});

app.Run();
