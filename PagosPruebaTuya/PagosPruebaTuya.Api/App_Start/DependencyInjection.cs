using PagosPruebaTuya.Business.DataTest;
using PagosPruebaTuya.Business.ProductOrder;
using PagosPruebaTuya.Common.Handler;
using PagosPruebaTuya.Common.Utils;
using PagosPruebaTuya.Common.Utils.LoggerTy;
using PagosPruebaTuya.Data.Repository;
using PagosPruebaTuya.Data.Repository.AddressEntity;
using PagosPruebaTuya.Data.Repository.DetailOrderEntity;
using PagosPruebaTuya.Data.Repository.OrderProductEntity;
using PagosPruebaTuya.Data.Repository.PaymentMethodEntity;
using PagosPruebaTuya.Data.Repository.ProductEntity;
using PagosPruebaTuya.Data.Repository.UserEntity;

namespace PagosPruebaTuya.API.App_Start
{
    public static class DependencyInjection
    {

        public static void RegisterDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuraction
            int minThreads = Convert.ToInt32(Environment.GetEnvironmentVariable("") ?? "1000");
            ThreadPool.SetMinThreads(minThreads, minThreads);
            ThreadPool.GetMinThreads(out int workerThreads, out int completionPortThreads);
            HelperConfiguration.Configuration = configuration;
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddControllers().AddJsonOptions(
                options => options.JsonSerializerOptions.PropertyNamingPolicy = null
                );

            //Business
            services.AddScoped(typeof(IDataTestBusiness), typeof(DataTestBusiness));
            services.AddScoped(typeof(IProductOrderBusiness), typeof(ProductOrderBusiness));

            //Common
            services.AddScoped(typeof(ILoggerTy<>), typeof(LoggerTy<>));
            services.AddScoped<ExceptionHandle>();

            //Data
            services.AddScoped(typeof(IDataTestRepository), typeof(DataTestRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IPaymentMethodRepository), typeof(PaymentMethodRepository));
            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));
            services.AddScoped(typeof(IOrderProductRepository), typeof(OrderProductRepository));
            services.AddScoped(typeof(IDetailOrderRepository), typeof(DetailOrderRepository));
        
            //Providers

        }

    }
}
