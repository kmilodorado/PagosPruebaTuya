using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using PagosPruebaTuya.Common.Enviroments;
using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Data.Repository;
using PagosPruebaTuya.Data.Repository.AddressEntity;
using PagosPruebaTuya.Data.Repository.PaymentMethodEntity;
using PagosPruebaTuya.Data.Repository.ProductEntity;
using PagosPruebaTuya.Data.Repository.UserEntity;
using PagosPruebaTuya.Dto.Config.Common;
using PagosPruebaTuya.Dto.V1.Map;
using System.Net;

namespace PagosPruebaTuya.Business.DataTest
{
    public class DataTestBusiness : BaseBusiness, IDataTestBusiness
    {
        private readonly IDataTestRepository _dataTestRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IAddressRepository _addressRepository;

        public DataTestBusiness(
            IDataTestRepository dataTestRepository, 
            IUserRepository userRepository, 
            IProductRepository productRepository,
            IPaymentMethodRepository paymentMethodRepository,
            IAddressRepository addressRepository)
        {
            _dataTestRepository = dataTestRepository ?? throw new ArgumentNullException(nameof(dataTestRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _paymentMethodRepository = paymentMethodRepository ?? throw new ArgumentNullException(nameof(paymentMethodRepository));
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        }

        public async Task<HttpResponseDto<object>> GetLoadData()
        {
            string fileDataTest = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "DataTest.json");
            string datajson = File.ReadAllText(fileDataTest);
            DataTestDto data = JsonConvert.DeserializeObject<DataTestDto>(datajson);
            List<User> users=await _userRepository.GetUsers();
            if (!users.Any())
            {
                foreach (var item in data.User)
                {
                    Guid id = await _userRepository.InsertUserAsync(item);
                    foreach (var address in item.Address)
                    {
                        address.fkUser_id = id;
                        await _addressRepository.InsertAddressAsync(address);
                    }
                }
                foreach (var item in data.Product)
                {
                    await _productRepository.InsertProductAsync(item);
                }
                foreach (var item in data.PaymentMethod)
                {
                    await _paymentMethodRepository.InsertPaymentMethodDtoAsync(item);
                }
                await _dataTestRepository.SaveChanges();
            }

            return await ReturnObjectResponse<object>(await _dataTestRepository.GetData(), Variables.Message.SUCCESS_MSG, HttpStatusCode.OK);
        }
    }
}
