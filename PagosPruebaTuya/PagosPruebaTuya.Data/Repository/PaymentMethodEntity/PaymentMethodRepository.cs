using Microsoft.EntityFrameworkCore;
using PagosPruebaTuya.Common.Utils;
using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Data.Models.AplicationDb;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.PaymentMethodEntity
{
    public class PaymentMethodRepository : BaseRepository, IPaymentMethodRepository
    {
        public PaymentMethodRepository(AplicationDbContext aplicationDbContext) : base(aplicationDbContext) { }

        public async Task<string?> GetPaymentMethod(int? id)
        {
            PaymentMethod? paymentMethod = await _aplicationDbContext.PaymentMethods
                    .Where(x => x.id == id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            return paymentMethod?.name;
        }

        public async Task<List<PaymentMethodDto>> GePaymentMethods()
        {

            List<PaymentMethod> paymentMethods = await _aplicationDbContext.PaymentMethods.AsNoTracking().ToListAsync();
            List<PaymentMethodDto> paymentMethodsDto = new List<PaymentMethodDto>();
            foreach (var item in paymentMethods)
            {
                paymentMethodsDto.Add(item.Clone<PaymentMethod, PaymentMethodDto>());
            }
            return paymentMethodsDto;
        }

        public async Task<int> InsertPaymentMethodDtoAsync(PaymentMethodDto payment)
        {
            PaymentMethod insertData = await InsertDb<PaymentMethod>(payment.Clone<PaymentMethodDto, PaymentMethod>());
            return insertData.id;
        }
    }
}
