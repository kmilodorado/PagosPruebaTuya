using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosPruebaTuya.Dto.V1.Request
{
    public class PagarOrdenRequestDto
    {
        public Guid userId { get; set; }
        public Guid codeProducto { get; set; }
        public int paymentMethod { get; set; }
    }
}
