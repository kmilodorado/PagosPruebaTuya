using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.OrderProductEntity
{
    public interface IOrderProductRepository
    {
        Task<OrderProduct?> GetOrderProduct(Guid id);
        Task<Guid> InsertOrderProductAsync(OrderProductDto orderProductDto);
        Task<List<OrderProduct>> GetOrderProducts(Guid userId);
        Task<bool> UpdateOrderProductsAsync(OrderProduct orderProduct);
        Task SaveChanges();
    }
}
