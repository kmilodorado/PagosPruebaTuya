using System.ComponentModel.DataAnnotations;

namespace PagosPruebaTuya.Data.Models
{
    public partial class User
    {
        [Key]
        public Guid id { get; set; }

        #region Contenido
        [Required, MaxLength(20)]
        public string userName { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string email { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string pass { get; set; } = string.Empty;
        #endregion

        #region Collection
        public ICollection<OrderProduct>? orders { get; set; }
        public ICollection<Address>? Addresses { get; set; }
        #endregion
    }
}
