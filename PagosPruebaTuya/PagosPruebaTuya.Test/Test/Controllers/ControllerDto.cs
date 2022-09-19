using PagosPruebaTuya.Dto.Config.Common;
using PagosPruebaTuya.Dto.V1.Request;
using PagosPruebaTuya.Dto.V1.Response;
using System.Collections.Generic;

namespace PagosPruebaTuya.Test.Test.Controllers
{
    public class ControllerDto
    {
       public HttpResponseDto<object> dataTestResponseDto { get; set; }
        public HttpResponseDto<List<ProductOrderResponseDto>> httpResponseDtoListProductOrderResponseDto { get; set; }
        public HttpResponseDto<ProductOrderResponseDto> httpResponseDtoProductOrderResponseDto { get; set; }
        public ProductOrderRequestDto productOrderRequestDto { get; set; }
        public PagarOrdenRequestDto pagarOrdenRequestDto { get; set; }
        
    }
}
