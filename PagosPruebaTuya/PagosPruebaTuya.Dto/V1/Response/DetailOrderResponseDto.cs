using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosPruebaTuya.Dto.V1.Response
{
    public class DetailOrderResponseDto
    {
        public int no { get; set; }
        public Guid CodeProduct { get; set; }
        public string nameProduct { get; set; } = string.Empty;
        public string descriptionProduct { get; set; } = string.Empty;
        public int quantity { get; set; } = 0;
        public decimal price { get; set; } = 0;
    }
}
