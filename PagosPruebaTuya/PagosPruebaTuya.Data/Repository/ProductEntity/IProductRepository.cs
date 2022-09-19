using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Dto.V1.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosPruebaTuya.Data.Repository.ProductEntity
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProducts();
        Task<Guid> InsertProductAsync(ProductDto product);
        Task<ProductDto> GetProduct(Guid id);
    }
}
