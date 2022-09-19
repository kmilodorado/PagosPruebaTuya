using PagosPruebaTuya.Common.Enviroments;
using PagosPruebaTuya.Common.Handler;
using PagosPruebaTuya.Common.Utils;
using PagosPruebaTuya.Data.Models;
using PagosPruebaTuya.Data.Repository.DetailOrderEntity;
using PagosPruebaTuya.Data.Repository.OrderProductEntity;
using PagosPruebaTuya.Data.Repository.PaymentMethodEntity;
using PagosPruebaTuya.Data.Repository.ProductEntity;
using PagosPruebaTuya.Data.Repository.UserEntity;
using PagosPruebaTuya.Dto.Config.Common;
using PagosPruebaTuya.Dto.V1.Map;
using PagosPruebaTuya.Dto.V1.Request;
using PagosPruebaTuya.Dto.V1.Response;
using System.Net;
using static PagosPruebaTuya.V1.Dto.Enumerators.Enumerators;

namespace PagosPruebaTuya.Business.ProductOrder
{
    public class ProductOrderBusiness : BaseBusiness, IProductOrderBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IDetailOrderRepository _detailOrderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public ProductOrderBusiness(IUserRepository userRepository, IOrderProductRepository orderProductRepository, IDetailOrderRepository detailOrderRepository, IProductRepository productRepository, IPaymentMethodRepository paymentMethodRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _orderProductRepository = orderProductRepository ?? throw new ArgumentNullException(nameof(orderProductRepository));
            _detailOrderRepository = detailOrderRepository ?? throw new ArgumentNullException(nameof(detailOrderRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _paymentMethodRepository = paymentMethodRepository ?? throw new ArgumentNullException(nameof(paymentMethodRepository));
        }

        public async Task<HttpResponseDto<ProductOrderResponseDto>> PagarOrden(PagarOrdenRequestDto pagarOrdenRequestDto)
        {
            UserAddressDto? userAddressDto = await ValidateUser(pagarOrdenRequestDto.userId.ToString());
            Guid id= await FacturarOrden(pagarOrdenRequestDto.codeProducto, userAddressDto.userName, pagarOrdenRequestDto.paymentMethod);
            ProductOrderResponseDto productOrderResponseDto = await GetOrdenProduct(userAddressDto, id);
            return await ReturnObjectResponse<ProductOrderResponseDto>(productOrderResponseDto, Variables.Message.SUCCESS_MSG, HttpStatusCode.OK);
        }

        public async Task<HttpResponseDto<ProductOrderResponseDto>> CreateOrden(ProductOrderRequestDto productOrderRequestDto)
        {
            if (!productOrderRequestDto.products.Any())
                throw new StatusCodeException(HttpStatusCode.UnprocessableEntity, Variables.Message.REQUIEREPRODUCT_MSG);

            UserAddressDto? userAddressDto = await ValidateUser(productOrderRequestDto.userId.ToString());

            OrderProductDto orderProductDto = new OrderProductDto()
            {
                id = Guid.NewGuid(),
                fkUser_id = userAddressDto.userid,
                fkAddress_id = userAddressDto.addressid,
                price = 0,
                stateOrden = EnumStateOrden.En_proceso,
                fkPaymentMethod_id = null,
                createdBy= userAddressDto.userName
            };

            Guid ordenId = await _orderProductRepository.InsertOrderProductAsync(orderProductDto);

            foreach (var item in productOrderRequestDto.products)
            {
                ProductDto product = await _productRepository.GetProduct(item.productId);
                await _detailOrderRepository.InsertDetailOrderAsync(new DetailOrderDto()
                {
                    fkOrder_id = ordenId,
                    fkProduct_id = item.productId,
                    quantity = item.quantity,
                    createdBy= userAddressDto.userName
                });
            }
            await _orderProductRepository.SaveChanges();

            ProductOrderResponseDto productOrderResponseDto = await GetOrdenProduct(userAddressDto, ordenId);

            return await ReturnObjectResponse<ProductOrderResponseDto>(productOrderResponseDto, Variables.Message.SUCCESS_MSG, HttpStatusCode.OK);
        }

        public async Task<HttpResponseDto<List<ProductOrderResponseDto>>> GetOrdens(string userId)
        {
            UserAddressDto? userAddressDto = await ValidateUser(userId);
            List<ProductOrderResponseDto> productOrderResponseDto = new List<ProductOrderResponseDto>();
            List<OrderProduct> ordens =await _orderProductRepository.GetOrderProducts(Guid.Parse(userId));
            foreach (var item in ordens)
            {
                productOrderResponseDto.Add(await GetOrdenProduct(userAddressDto, item.id));
            }
            return await ReturnObjectResponse<List<ProductOrderResponseDto>>(productOrderResponseDto, Variables.Message.SUCCESS_MSG, HttpStatusCode.OK);
        }

        public async Task<HttpResponseDto<ProductOrderResponseDto>> GetOrden(string userId, string ordenId)
        {
            UserAddressDto? userAddressDto = await ValidateUser(userId);
            ProductOrderResponseDto productOrderResponseDto = await GetOrdenProduct(userAddressDto, Guid.Parse(ordenId));
            return await ReturnObjectResponse<ProductOrderResponseDto>(productOrderResponseDto, Variables.Message.SUCCESS_MSG, HttpStatusCode.OK);
        }

        private async Task<Guid> FacturarOrden(Guid codeOrden, string userName, int payment)
        {
            decimal total = 0;
            List<DetailOrder> detail = await _detailOrderRepository.GetDetailOrders(codeOrden);
            foreach (var item in detail)
            {
                ProductDto productDto = await _productRepository.GetProduct(item.fkProduct_id);
                bool exito = await _detailOrderRepository.UpdateDetailOrderAsync(new DetailOrderDto()
                {
                    id = item.id,
                    fkOrder_id = item.fkOrder_id,
                    fkProduct_id = item.fkOrder_id,
                    quantity = item.quantity,
                    price= productDto.price,
                    lastModified= ColombiaHour.GetDate(),
                    lastModifiedBy= userName,
                    
                });
                if (!exito)
                    throw new StatusCodeException(HttpStatusCode.InternalServerError, Variables.Message.ERROR_GENERAL);
                total += item.quantity * productDto.price;
            }
            
            bool exitoOrden = await _orderProductRepository.UpdateOrderProductsAsync(new OrderProduct()
            {
                id = codeOrden,
                stateOrden=EnumStateOrden.Enviando,
                fkPaymentMethod_id= payment,
                price = total,
                lastModified = ColombiaHour.GetDate(),
                lastModifiedBy = userName,

            });
            if (!exitoOrden)
                throw new StatusCodeException(HttpStatusCode.InternalServerError, Variables.Message.ERROR_GENERAL);
            return codeOrden;
        }

        private async Task<UserAddressDto> ValidateUser(string userId)
        {
            UserAddressDto? userAddressDto = await _userRepository.GetUsers(Guid.Parse(userId));

            if (userAddressDto == null)
                throw new StatusCodeException(HttpStatusCode.BadRequest, Variables.Message.NOCONTENTPROCESS_MSG);
            return userAddressDto;
        }

        private async Task<ProductOrderResponseDto> GetOrdenProduct(UserAddressDto? userAddressDto, Guid ordenId)
        {
            List<DetailOrder> detail = await _detailOrderRepository.GetDetailOrders(ordenId);
            List<DetailOrderResponseDto> detailOrders = new List<DetailOrderResponseDto>();
            int count = 1;
            foreach (var item in detail)
            {
                ProductDto productDto = await _productRepository.GetProduct(item.fkProduct_id);
                detailOrders.Add(new DetailOrderResponseDto()
                {
                    no = count,
                    CodeProduct = item.fkProduct_id,
                    nameProduct = productDto.name,
                    descriptionProduct = productDto.description,
                    quantity = item.quantity,
                    price = item.price
                });
                count++;
            }


            OrderProduct orderProduct = await _orderProductRepository.GetOrderProduct(ordenId);
            
            ProductOrderResponseDto productOrderResponseDto = new ProductOrderResponseDto()
            {

                codeOrden = orderProduct.id,
                paymentMethod = await _paymentMethodRepository.GetPaymentMethod(orderProduct.fkPaymentMethod_id),
                stateOrden = orderProduct.stateOrden,
                userName = new UserResponseDto()
                {
                    codeUser = userAddressDto.userid,
                    userName = userAddressDto.userName,
                    email = userAddressDto.email
                },
                address = new AddressResponseDto()
                {
                    country = userAddressDto.country,
                    city = userAddressDto.city,
                    quarter = userAddressDto.quarter,
                    streetType = userAddressDto.streetType,
                    street = userAddressDto.street,
                    numberExt = userAddressDto.numberExt,
                    numberInt = userAddressDto.numberInt
                },
                detailOrders = detailOrders
            };
            return productOrderResponseDto;
        }
    }
}
