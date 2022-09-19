using Microsoft.EntityFrameworkCore;
using PagosPruebaTuya.Common.Utils;
using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Data.Models.AplicationDb;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.DetailOrderEntity
{
    public class DetailOrderRepository : BaseRepository, IDetailOrderRepository
    {
        public DetailOrderRepository(AplicationDbContext aplicationDbContext) : base(aplicationDbContext) {}

        public async Task<List<DetailOrder>> GetDetailOrders(Guid id)
        {
            return await _aplicationDbContext.DetailOrders
                    .Where(x => x.fkOrder_id == id)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<int> InsertDetailOrderAsync(DetailOrderDto orderProductDto)
        {
            DetailOrder insertData = await InsertDb(orderProductDto.Clone<DetailOrderDto, DetailOrder>());
            return insertData.id;
        }

        public async Task<bool> UpdateDetailOrderAsync(DetailOrderDto orderProductDto)
        {
            try
            {
                DetailOrder detailOrder = orderProductDto.Clone<DetailOrderDto, DetailOrder>();
                _aplicationDbContext.Entry(detailOrder).Property(x => x.price).IsModified = true;
                _aplicationDbContext.Entry(detailOrder).Property(x => x.lastModified).IsModified = true;
                _aplicationDbContext.Entry(detailOrder).Property(x => x.lastModifiedBy).IsModified = true;
                await SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
