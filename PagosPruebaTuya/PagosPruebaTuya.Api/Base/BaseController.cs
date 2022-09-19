using Microsoft.AspNetCore.Mvc;
using PagosPruebaTuya.Dto.Config.Common;
using System.Net;

namespace PagosPruebaTuya.Api.Base
{
    [ApiController]
    [ProducesResponseType(typeof(HttpResponseErrorDto), 500)]
    [ProducesResponseType(typeof(HttpResponseDto<string>), 400)]
    [ProducesResponseType(typeof(HttpResponseDto<string>), 401)]
    [ProducesResponseType(typeof(HttpResponseDto<string>), 404)]
    public class BaseController : Controller
    {
        public async Task<ObjectResult> GetResponseAnswer<T>(HttpStatusCode code, string message, T? response, bool isError)
        {
            return await Task.Run(() =>
            {
                object? objResult = null;

                if (isError)
                {
                    objResult = new HttpResponseErrorDto()
                    {
                        Codigo = (int)code,
                        Mensaje = message
                    };

                    return new ObjectResult(objResult)
                    {
                        StatusCode = (int)code
                    };
                }

                objResult = new HttpResponseDto<T>
                {
                    Codigo = (int)code,
                    Descripcion = message,
                    Objeto = response
                };

                return new ObjectResult(objResult)
                {
                    StatusCode = (int)code
                };
            });
        }
    }
}
