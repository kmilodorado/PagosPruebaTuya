using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PagosPruebaTuya.Data.Models
{
    public partial class PaymentMethod : AudiTableEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        #region Contenido
        [Required, MaxLength(50)]
        public string name { get; set; } = string.Empty;
        #endregion

        #region Collection
        public ICollection<OrderProduct>? orders { get; set; }
        #endregion
    }
}
