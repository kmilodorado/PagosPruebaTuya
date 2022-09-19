using System.ComponentModel.DataAnnotations;

namespace PagosPruebaTuya.Data.Models
{
    public abstract class AudiTableEntity
    {
        [Required]
        public DateTime created { get; set; }
        [Required]
        public string createdBy { get; set; } = "SystemTuyaPagos";
        public DateTime? lastModified { get; set; }
        public string? lastModifiedBy { get; set; }
    }
}
