using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PagosPruebaTuya.V1.Dto.Enumerators.Enumerators;

namespace PagosPruebaTuya.Dto.V1.Response
{
    public class ProductOrderResponseDto
    {
        public Guid codeOrden { get; set; }
        public string paymentMethod { get; set; }= string.Empty;
        public EnumStateOrden stateOrden { get; set; } = 0;
        public string stateOrdenName { get { return StateOrden(this.stateOrden); } }
        public UserResponseDto userName { get; set; }

        public AddressResponseDto address { get; set; }

        public List<DetailOrderResponseDto> detailOrders { get; set; }
    }
}
