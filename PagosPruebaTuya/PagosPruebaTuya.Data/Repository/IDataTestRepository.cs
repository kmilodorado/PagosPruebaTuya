using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository
{
    public interface IDataTestRepository
    {
        Task<DataTestDto> GetData();
        Task SaveChanges();
    }
}
