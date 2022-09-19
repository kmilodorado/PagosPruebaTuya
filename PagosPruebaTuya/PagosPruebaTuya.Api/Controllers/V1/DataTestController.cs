using Microsoft.AspNetCore.Mvc;
using PagosPruebaTuya.Api.Base;
using PagosPruebaTuya.Business.DataTest;
using PagosPruebaTuya.Dto.Config.Common;
using System.Net;

namespace PagosPruebaTuya.Api.Controllers.V1
{
    [Route("api/[controller]/v1")]
    public class DataTestController : BaseController
    {
        private readonly IDataTestBusiness _dataTestBusiness;
        public DataTestController(IDataTestBusiness dataTestBusiness)
        {
            _dataTestBusiness = dataTestBusiness ?? throw new ArgumentNullException(nameof(dataTestBusiness));
        }

        [HttpGet("GetLoadData")]
        [ProducesResponseType(typeof(HttpResponseDto<string>), 200)]
        public async Task<ActionResult> GetLoadData()
        {
            HttpResponseDto<object> objectResponse = await _dataTestBusiness.GetLoadData();
            return await GetResponseAnswer<object>((HttpStatusCode)objectResponse.Codigo, objectResponse.Descripcion, objectResponse.Objeto, false);
        }
    }
}
