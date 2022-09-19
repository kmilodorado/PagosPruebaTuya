using Moq;
using Newtonsoft.Json;
using PagosPruebaTuya.Api.Base;
using PagosPruebaTuya.Dto.Config.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PagosPruebaTuya.Test.Test.Base
{
    public class BaseControllerTest
    {
        private readonly MockRepository mockRepository;

        public BaseControllerTest()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        public BaseController CreateBaseController()
        {
            return new BaseController();
        }

        [Fact]
        public async Task GetResponseAnswerIsNotError()
        {
            //Arrange
            var baseController = CreateBaseController();
            HttpStatusCode code = HttpStatusCode.OK;
            string message = "Prueba";
            string responseValue = null;
            bool isError = false;
            HttpResponseDto<string> httpResponseDto= new HttpResponseDto<string>()
            {
                Codigo=(int)code,
                Descripcion=message,
                Objeto=responseValue
            };
            var result = await baseController.GetResponseAnswer(code,message,responseValue,isError);
            HttpResponseDto<string> response = (HttpResponseDto<string>)result.Value;
            Assert.Equal(JsonConvert.SerializeObject(httpResponseDto), JsonConvert.SerializeObject(response));
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetResponseAnswerIsError()
        {
            //Arrange
            var baseController = CreateBaseController();
            HttpStatusCode code = HttpStatusCode.Forbidden;
            string message = "Prueba";
            string responseValue = null;
            bool isError = true;
            HttpResponseErrorDto httpResponseDto = new HttpResponseErrorDto()
            {
                Codigo = (int)code,
                Mensaje = message
            };
            var result = await baseController.GetResponseAnswer(code, message, responseValue, isError);
            HttpResponseErrorDto response = (HttpResponseErrorDto)result.Value;
            Assert.Equal(JsonConvert.SerializeObject(httpResponseDto), JsonConvert.SerializeObject(response));
            this.mockRepository.VerifyAll();
        }
    }
}
