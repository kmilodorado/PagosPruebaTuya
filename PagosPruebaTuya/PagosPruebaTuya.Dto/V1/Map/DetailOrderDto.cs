namespace PagosPruebaTuya.Dto.V1.Map
{
    public class DetailOrderDto
    {
        public int id { get; set; }
        public int quantity { get; set; } = 0;

        public decimal price { get; set; } = 0;

        public Guid fkOrder_id { get; set; }

        public Guid fkProduct_id { get; set; }
        public string createdBy { get; set; } = "SystemTuyaPagos";
        public DateTime? lastModified { get; set; }
        public string? lastModifiedBy { get; set; }
    }
}
