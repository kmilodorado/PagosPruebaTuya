namespace PagosPruebaTuya.Dto.V1.Map
{
    public class UserDto
    {
        public Guid? id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string pass { get; set; } = string.Empty;
        public List<AddressDto> Address { get; set; }
    }
}
