using Microsoft.AspNetCore.Mvc;
using PagosPruebaTuya.Api.Base;
using PagosPruebaTuya.Business.ProductOrder;
using PagosPruebaTuya.Dto.Config.Common;
using PagosPruebaTuya.Dto.V1.Request;
using PagosPruebaTuya.Dto.V1.Response;
using System.Net;

namespace PagosPruebaTuya.Api.Controllers.V1
{

    [Route("api/[controller]/v1")]
    public class ProductOrderController : BaseController
    {
        private readonly IProductOrderBusiness _productOrderBusiness;
        public ProductOrderController(IProductOrderBusiness productOrderBusiness)
        {
            _productOrderBusiness = productOrderBusiness ?? throw new ArgumentNullException(nameof(productOrderBusiness));
        }

        [HttpGet("GetOrdens")]
        [ProducesResponseType(typeof(HttpResponseDto<string>), 200)]
        public async Task<ActionResult> GetOrdens(string userid)
        {
            HttpResponseDto<List<ProductOrderResponseDto>> objectResponse = await _productOrderBusiness.GetOrdens(userid);
            return await GetResponseAnswer((HttpStatusCode)objectResponse.Codigo, objectResponse.Descripcion, objectResponse.Objeto, false);
        }

        [HttpGet("GetOrden")]
        [ProducesResponseType(typeof(HttpResponseDto<string>), 200)]
        public async Task<ActionResult> GetOrden(string userid, string ordenid)
        {
            HttpResponseDto<ProductOrderResponseDto> objectResponse = await _productOrderBusiness.GetOrden(userid, ordenid);
            return await GetResponseAnswer<ProductOrderResponseDto>((HttpStatusCode)objectResponse.Codigo, objectResponse.Descripcion, objectResponse.Objeto, false);
        }

        [HttpPost("CreateOrden")]
        [ProducesResponseType(typeof(HttpResponseDto<string>), 200)]
        public async Task<ActionResult> CreateOrden([FromBody] ProductOrderRequestDto productOrderRequestDto)
        {
            HttpResponseDto<ProductOrderResponseDto> objectResponse = await _productOrderBusiness.CreateOrden(productOrderRequestDto);
            return await GetResponseAnswer((HttpStatusCode)objectResponse.Codigo, objectResponse.Descripcion, objectResponse.Objeto, false);
        }


        [HttpPut("PagarOrden")]
        [ProducesResponseType(typeof(HttpResponseDto<string>), 200)]
        public async Task<ActionResult> PagarOrden([FromBody] PagarOrdenRequestDto pagarOrdenRequestDto)
        {
            HttpResponseDto<ProductOrderResponseDto> objectResponse = await _productOrderBusiness.PagarOrden(pagarOrdenRequestDto);
            return await GetResponseAnswer((HttpStatusCode)objectResponse.Codigo, objectResponse.Descripcion, objectResponse.Objeto, false);
        }

        
    }
}
