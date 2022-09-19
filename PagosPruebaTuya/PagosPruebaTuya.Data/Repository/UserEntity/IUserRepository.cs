using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository.UserEntity
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<UserAddressDto?> GetUsers(Guid id);
        Task<Guid> InsertUserAsync(UserDto userDto);
        Task<User> MapUserDtoToUser(UserDto user);
        Task<UserDto> MapUserToUserDto(User user);
    }
}
