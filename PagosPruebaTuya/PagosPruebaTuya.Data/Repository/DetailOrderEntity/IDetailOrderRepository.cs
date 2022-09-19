using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.DetailOrderEntity
{
    public interface IDetailOrderRepository
    {
        Task<int> InsertDetailOrderAsync(DetailOrderDto orderProductDto);
        Task<List<DetailOrder>> GetDetailOrders(Guid id);
        Task<bool> UpdateDetailOrderAsync(DetailOrderDto orderProductDto);
    }
}
