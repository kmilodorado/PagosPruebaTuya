namespace PagosPruebaTuya.Dto.V1.Map
{
    public class ProductDto
    {
        public Guid id { get; set; }

        public string name { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public decimal price { get; set; } = 0;
    }
}
