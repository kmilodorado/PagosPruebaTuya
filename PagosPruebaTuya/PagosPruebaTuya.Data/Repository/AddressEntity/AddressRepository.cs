using Microsoft.EntityFrameworkCore;
using PagosPruebaTuya.Common.Utils;
using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Data.Models.AplicationDb;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.AddressEntity
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(AplicationDbContext aplicationDbContext) : base(aplicationDbContext) { }

        public async Task<List<AddressDto>> GetAddresses(Guid? id)
        {
            List<Address> Addresses = await _aplicationDbContext.Addresses.Where(x => x.fkUser_id == id).AsNoTracking().ToListAsync();
            List<AddressDto> AddressesDto = new List<AddressDto>();
            foreach (var item in Addresses)
            {
                AddressesDto.Add(item.Clone<Address, AddressDto>());
            }
            return AddressesDto;
        }

        public async Task<int> InsertAddressAsync(AddressDto addressDto)
        {
            Address insertData = await InsertDb(addressDto.Clone<AddressDto, Address>());
            return insertData.id;
        }

    }
}
