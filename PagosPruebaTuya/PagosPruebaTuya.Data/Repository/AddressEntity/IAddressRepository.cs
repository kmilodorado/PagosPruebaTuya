using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.AddressEntity
{
    public interface IAddressRepository
    {
        Task<int> InsertAddressAsync(AddressDto addressDto);
        Task<List<AddressDto>> GetAddresses(Guid? id);
    }
}
