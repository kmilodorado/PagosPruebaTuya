using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PagosPruebaTuya.Data.Models
{
    public partial class Product : AudiTableEntity
    {

        [Key]
        public Guid id { get; set; }

        #region Contenido
        [Required, MaxLength(200)]
        public string name { get; set; } = string.Empty;

        [Required]
        public string description { get; set; } = string.Empty;

        [Required]
        public decimal price { get; set; } = 0;

        #endregion

        #region Collection
        public ICollection<DetailOrder>? DetailOrders { get; set; }
        #endregion
    }
}
