using Microsoft.AspNetCore.Mvc;
using Moq;
using PagosPruebaTuya.Api.Controllers.V1;
using PagosPruebaTuya.Business.DataTest;
using PagosPruebaTuya.Common.Utils;
using PagosPruebaTuya.Test.Common;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PagosPruebaTuya.Test.Test.Controllers.V1
{
    public class DataTestControllerTest: BaseTest
    {
        private readonly MockRepository mockRepository;
        private readonly Mock<IDataTestBusiness> mockDataTestBusiness;

        public DataTestControllerTest()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockDataTestBusiness = this.mockRepository.Create<IDataTestBusiness>();
        }

        private DataTestController InitDataTestController(IDataTestBusiness dataTestBusiness)
        {
            return new DataTestController(dataTestBusiness);
        }

        [Fact]
        public void ArgumentNullException_IDataTestBusiness()
        {
            IDataTestBusiness parameter = null;
            Assert.Throws<ArgumentNullException>(() => InitDataTestController(parameter));
            this.mockRepository.VerifyAll();
        }

        private DataTestController CreateDataTestController()
        {
            return new DataTestController(this.mockDataTestBusiness.Object);
        }

        [Fact]
        public async Task GetLoadDataSuccess()
        {
            var constructor= this.CreateDataTestController();
            ControllerDto dataJsonDto = base.ReadData<ControllerDto>(Constants.JSON_CONTROLLERTEST);
            mockDataTestBusiness.Setup(x => x.GetLoadData()).ReturnsAsync(() =>
            {
                return dataJsonDto.dataTestResponseDto;
            });

            //Act
            var result = await constructor.GetLoadData();

            //Assert
            var objectResult=Assert.IsType<ObjectResult>(result);
            Assert.Equal(dataJsonDto.dataTestResponseDto.Serialize(), objectResult.Value.Serialize());
            this.mockRepository.VerifyAll();
        }
    }
}
