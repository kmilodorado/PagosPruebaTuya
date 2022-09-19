using Microsoft.EntityFrameworkCore;
using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Data.Models.AplicationDb;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.UserEntity
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AplicationDbContext aplicationDbContext) : base(aplicationDbContext) { }

        public async Task<List<User>> GetUsers()
        {
            return await _aplicationDbContext.Users.ToListAsync();
        }

        public async Task<UserAddressDto?> GetUsers(Guid id)
        {
            var query = await _aplicationDbContext.Users
                    .Join(_aplicationDbContext.Addresses,
                        user => user.id,
                        address => address.fkUser_id,
                        (user, address) => new
                        {
                            userid = user.id,
                            userName = user.userName,
                            email = user.email,
                            adressid = address.id,
                            country = address.country,
                            city = address.city,
                            quarter = address.quarter,
                            streetType = address.streetType,
                            street = address.street,
                            numberExt = address.numberExt,
                            numberInt = address.numberInt,
                            addressState =address.state
                        })
                    .Where(x => x.userid == id && (bool)x.addressState)
                    .Select(x => new UserAddressDto()
                    {
                        userid = x.userid,
                        userName=x.userName,
                        email=x.email,
                        addressid = x.adressid,
                        country = x.country,
                        city = x.city,
                        quarter = x.quarter,
                        streetType = x.streetType,
                        street = x.street,
                        numberExt = x.numberExt,
                        numberInt = x.numberInt

                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

            return query;
        }

        public async Task<Guid> InsertUserAsync(UserDto userDto)
        {
            User insertData = await InsertDb(await MapUserDtoToUser(userDto));
            return insertData.id;
        }

        public Task<User> MapUserDtoToUser(UserDto user)
        {
            return Task.FromResult(new User()
            {
                id = user.id ?? Guid.NewGuid(),
                userName = user.userName,
                email = user.email,
                pass = user.pass
            });
        }

        public Task<UserDto> MapUserToUserDto(User user)
        {
            return Task.FromResult(new UserDto()
            {
                id = user.id,
                userName = user.userName,
                email = user.email
            });
        }
    }
}
