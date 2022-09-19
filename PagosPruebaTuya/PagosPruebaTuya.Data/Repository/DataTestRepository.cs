using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Data.Models.AplicationDb;
using PagosPruebaTuya.Data.Repository.AddressEntity;
using PagosPruebaTuya.Data.Repository.PaymentMethodEntity;
using PagosPruebaTuya.Data.Repository.ProductEntity;
using PagosPruebaTuya.Data.Repository.UserEntity;
using PagosPruebaTuya.Dto.V1.Map;

namespace PagosPruebaTuya.Data.Repository
{
    public class DataTestRepository : BaseRepository, IDataTestRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IAddressRepository _addressRepository;
        public DataTestRepository(AplicationDbContext aplicationDbContext, 
            IUserRepository userRepository,
            IProductRepository productRepository,
            IPaymentMethodRepository paymentMethodRepository,
            IAddressRepository addressRepository) : base(aplicationDbContext)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _paymentMethodRepository = paymentMethodRepository ?? throw new ArgumentNullException(nameof(paymentMethodRepository));
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        }

        public async Task<DataTestDto> GetData()
        {
            List<User> user = await _userRepository.GetUsers();
            List<UserDto> userDto= new List<UserDto>();
            foreach (var item in user)
            {
                UserDto userNew = await _userRepository.MapUserToUserDto(item);
                userNew.Address = await _addressRepository.GetAddresses(userNew.id);
                userDto.Add(userNew);
            }

            DataTestDto dataTest = new DataTestDto()
            {
                User = userDto,
                Product= await _productRepository.GetProducts(),
                PaymentMethod= await _paymentMethodRepository.GePaymentMethods(),
            };
            return dataTest;
        }
    }
}
