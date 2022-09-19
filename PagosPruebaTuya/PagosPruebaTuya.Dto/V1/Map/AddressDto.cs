using static PagosPruebaTuya.V1.Dto.Enumerators.Enumerators;

namespace PagosPruebaTuya.Dto.V1.Map
{
    public class AddressDto
    {
        public int id { get; set; }
        public string country { get; set; } = string.Empty;

        public int city { get; set; }

        public string quarter { get; set; } = string.Empty;

        public EnumStreetType streetType { get; set; }

        public string street { get; set; } = string.Empty;

        public string numberExt { get; set; } = string.Empty;

        public int numberInt { get; set; }

        public bool? state { get; set; }

        public Guid fkUser_id { get; set; }
    }
}
