using Microsoft.EntityFrameworkCore;
using PagosPruebaTuya.Common.Utils;
using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Data.Models.AplicationDb;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.OrderProductEntity
{
    public class OrderProductRepository : BaseRepository, IOrderProductRepository
    {
        public OrderProductRepository(AplicationDbContext aplicationDbContext) : base(aplicationDbContext){}

        public async Task<OrderProduct?> GetOrderProduct(Guid id)
        {
            return await _aplicationDbContext.Orders
                    .Where(x => x.id == id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }
        public async Task<List<OrderProduct>> GetOrderProducts(Guid userId)
        {
            return await _aplicationDbContext.Orders
                    .Where(x => x.fkUser_id == userId)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<bool> UpdateOrderProductsAsync(OrderProduct orderProduct)
        {
            try
            {
                _aplicationDbContext.Entry(orderProduct).Property(x => x.fkPaymentMethod_id).IsModified = true;
                _aplicationDbContext.Entry(orderProduct).Property(x => x.stateOrden).IsModified = true;
                _aplicationDbContext.Entry(orderProduct).Property(x => x.price).IsModified = true;
                _aplicationDbContext.Entry(orderProduct).Property(x => x.lastModified).IsModified = true;
                _aplicationDbContext.Entry(orderProduct).Property(x => x.lastModifiedBy).IsModified = true;
                await SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<Guid> InsertOrderProductAsync(OrderProductDto orderProductDto)
        {
            OrderProduct insertData = await InsertDb(orderProductDto.Clone<OrderProductDto, OrderProduct>());
            return insertData.id;
        }
    }
}
