using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.PaymentMethodEntity
{
    public interface IPaymentMethodRepository
    {
        Task<string> GetPaymentMethod(int? id);
        Task<List<PaymentMethodDto>> GePaymentMethods();
        Task<int> InsertPaymentMethodDtoAsync(PaymentMethodDto payment);
    }
}
