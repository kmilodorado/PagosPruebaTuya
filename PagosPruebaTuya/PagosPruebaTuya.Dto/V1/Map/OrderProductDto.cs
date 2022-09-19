using static PagosPruebaTuya.V1.Dto.Enumerators.Enumerators;

namespace PagosPruebaTuya.Dto.V1.Map
{
    public class OrderProductDto
    {
        public Guid id { get; set; }
        public EnumStateOrden stateOrden { get; set; }
        public decimal price { get; set; } = 0;

        public Guid fkUser_id { get; set; }

        public int fkAddress_id { get; set; }

        public int? fkPaymentMethod_id { get; set; }
        public string createdBy { get; set; } = "SystemTuyaPagos";
        public DateTime? lastModified { get; set; }
        public string? lastModifiedBy { get; set; }
    }
}
