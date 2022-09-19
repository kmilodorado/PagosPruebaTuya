using Microsoft.EntityFrameworkCore;
using PagosPruebaTuya.Common.Utils;
using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Data.Models.AplicationDb;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.ProductEntity
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AplicationDbContext aplicationDbContext) : base(aplicationDbContext) { }
        public async Task<List<ProductDto>> GetProducts()
        {
            List<Product> products = await _aplicationDbContext.Products.AsNoTracking().ToListAsync();
            List<ProductDto> productDtos = new List<ProductDto>();
            foreach (var item in products)
            {
                productDtos.Add(item.Clone<Product, ProductDto>());
            }
            return productDtos;
        }

        public async Task<ProductDto> GetProduct(Guid id)
        {
            Product? products = await _aplicationDbContext.Products
                .Where(x=>x.id==id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return products.Clone<Product, ProductDto>();
        }

        public async Task<Guid> InsertProductAsync(ProductDto product)
        {
            Product insertData = await InsertDb<Product>(product.Clone<ProductDto, Product>());
            return insertData.id;
        }
    }
}
