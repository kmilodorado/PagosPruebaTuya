using PagosPruebaTuya.Dto.Config.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosPruebaTuya.Business.DataTest
{
    public interface IDataTestBusiness
    {
        Task<HttpResponseDto<object>> GetLoadData();
    }
}
