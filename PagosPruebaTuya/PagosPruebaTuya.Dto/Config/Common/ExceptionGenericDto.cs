using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosPruebaTuya.Dto.Config.Common
{
    public class ExceptionGenericDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
