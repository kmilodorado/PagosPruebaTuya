using Microsoft.AspNetCore.Mvc;
using Moq;
using PagosPruebaTuya.Api.Controllers.V1;
using PagosPruebaTuya.Business.ProductOrder;
using PagosPruebaTuya.Common.Utils;
using PagosPruebaTuya.Dto.V1.Request;
using PagosPruebaTuya.Test.Common;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PagosPruebaTuya.Test.Test.Controllers.V1
{
    public class ProductOrderControllerTest: BaseTest
    {
        private readonly MockRepository mockRepository;
        private readonly Mock<IProductOrderBusiness> mockIProductOrderBusiness;

        public ProductOrderControllerTest()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockIProductOrderBusiness = this.mockRepository.Create<IProductOrderBusiness>();
        }

        private ProductOrderController InitProductOrderController(IProductOrderBusiness dataTestBusiness)
        {
            return new ProductOrderController(dataTestBusiness);
        }

        [Fact]
        public void ArgumentNullException_IProductOrderBusiness()
        {
            IProductOrderBusiness parameter = null;
            Assert.Throws<ArgumentNullException>(() => InitProductOrderController(parameter));
            this.mockRepository.VerifyAll();
        }

        private ProductOrderController CreateProductOrderController()
        {
            return new ProductOrderController(this.mockIProductOrderBusiness.Object);
        }

        [Fact]
        public async Task GetOrdensSuccess()
        {
            var constructor = this.CreateProductOrderController();
            ControllerDto dataJsonDto = base.ReadData<ControllerDto>(Constants.JSON_CONTROLLERTEST);
            mockIProductOrderBusiness.Setup(x => x.GetOrdens(It.IsAny<string>())).ReturnsAsync(() =>
            {
                return dataJsonDto.httpResponseDtoListProductOrderResponseDto;
            });

            //Act
            var result = await constructor.GetOrdens("f83d79f4-429e-4c99-b930-9a6f2b6917c6");

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(dataJsonDto.httpResponseDtoListProductOrderResponseDto.Serialize(), objectResult.Value.Serialize());
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public async Task GetOrdenSuccess()
        {
            var constructor = this.CreateProductOrderController();
            ControllerDto dataJsonDto = base.ReadData<ControllerDto>(Constants.JSON_CONTROLLERTEST);
            mockIProductOrderBusiness.Setup(x => x.GetOrden(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(() =>
            {
                return dataJsonDto.httpResponseDtoProductOrderResponseDto;
            });

            //Act
            var result = await constructor.GetOrden("f83d79f4-429e-4c99-b930-9a6f2b6917c6", "0724941c-f33e-4ac8-ac81-240298c6ac60");

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(dataJsonDto.httpResponseDtoProductOrderResponseDto.Serialize(), objectResult.Value.Serialize());
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public async Task CreateOrdenSuccess()
        {
            var constructor = this.CreateProductOrderController();
            ControllerDto dataJsonDto = base.ReadData<ControllerDto>(Constants.JSON_CONTROLLERTEST);
            mockIProductOrderBusiness.Setup(x => x.CreateOrden(It.IsAny<ProductOrderRequestDto>())).ReturnsAsync(() =>
            {
                return dataJsonDto.httpResponseDtoProductOrderResponseDto;
            });

            //Act
            var result = await constructor.CreateOrden(dataJsonDto.productOrderRequestDto);

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(dataJsonDto.httpResponseDtoProductOrderResponseDto.Serialize(), objectResult.Value.Serialize());
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task PagarOrdenSuccess()
        {
            var constructor = this.CreateProductOrderController();
            ControllerDto dataJsonDto = base.ReadData<ControllerDto>(Constants.JSON_CONTROLLERTEST);
            mockIProductOrderBusiness.Setup(x => x.PagarOrden(It.IsAny<PagarOrdenRequestDto>())).ReturnsAsync(() =>
            {
                return dataJsonDto.httpResponseDtoProductOrderResponseDto;
            });

            //Act
            var result = await constructor.PagarOrden(dataJsonDto.pagarOrdenRequestDto);

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(dataJsonDto.httpResponseDtoProductOrderResponseDto.Serialize(), objectResult.Value.Serialize());
            this.mockRepository.VerifyAll();
        }
    }
}
