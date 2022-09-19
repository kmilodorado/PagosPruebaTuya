using PagosPruebaTuya.Data.Models.AplicationDb;
namespace PagosPruebaTuya.Data
{
    public class BaseRepository
    {
        protected readonly AplicationDbContext _aplicationDbContext;

        public BaseRepository(AplicationDbContext aplicationDbContext)
        {
            _aplicationDbContext = aplicationDbContext ?? throw new ArgumentNullException(nameof(aplicationDbContext));
        }

        protected async Task<T> InsertDb<T>(T entity) where T : class
        {
            await _aplicationDbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        protected async Task<T> InsertDbSave<T>(T entity) where T : class
        {
            await _aplicationDbContext.Set<T>().AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task SaveChanges()
        {
            await _aplicationDbContext.SaveChangesAsync();
        }
    }
}
