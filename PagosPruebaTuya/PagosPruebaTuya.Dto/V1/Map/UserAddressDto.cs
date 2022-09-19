using static PagosPruebaTuya.V1.Dto.Enumerators.Enumerators;

namespace PagosPruebaTuya.Dto.V1.Map
{
    public class UserAddressDto
    {
        public Guid userid { get; set; }
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int addressid { get; set; }
        public string country { get; set; } = string.Empty;
        public int city { get; set; }
        public string quarter { get; set; } = string.Empty;
        public EnumStreetType streetType { get; set; }
        public string street { get; set; } = string.Empty;
        public string numberExt { get; set; } = string.Empty;
        public int numberInt { get; set; }
    }
}
