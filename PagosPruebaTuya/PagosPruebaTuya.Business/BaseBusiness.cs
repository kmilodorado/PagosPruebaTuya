using PagosPruebaTuya.Dto.Config.Common;
using System.Net;

namespace PagosPruebaTuya.Business
{
    public class BaseBusiness
    {
        protected Task<HttpResponseDto<TResponse>> ReturnObjectResponse<TResponse>(TResponse? response, string message, HttpStatusCode code) where TResponse : class
        {
            return Task.FromResult(new HttpResponseDto<TResponse>()
            {
                Codigo = (int)code,
                Descripcion = message,
                Objeto = response
            });
        }
    }
}
