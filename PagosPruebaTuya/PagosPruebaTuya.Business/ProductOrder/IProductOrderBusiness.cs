using PagosPruebaTuya.Dto.Config.Common;
using PagosPruebaTuya.Dto.V1.Request;
using PagosPruebaTuya.Dto.V1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosPruebaTuya.Business.ProductOrder
{
    public interface IProductOrderBusiness
    {
        Task<HttpResponseDto<List<ProductOrderResponseDto>>> GetOrdens(string userId);
        Task<HttpResponseDto<ProductOrderResponseDto>> GetOrden(string userId, string ordenId);
        Task<HttpResponseDto<ProductOrderResponseDto>> CreateOrden(ProductOrderRequestDto productOrderRequestDto);
        Task<HttpResponseDto<ProductOrderResponseDto>> PagarOrden(PagarOrdenRequestDto pagarOrdenRequestDto);
    }
}
