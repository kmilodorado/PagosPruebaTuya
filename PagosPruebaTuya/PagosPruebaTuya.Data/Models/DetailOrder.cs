using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PagosPruebaTuya.Data.Models
{
    public partial class DetailOrder : AudiTableEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        #region Contenido
        [Required]
        public int quantity { get; set; } = 0;

        [Required]
        public decimal price { get; set; } = 0;

        public Guid fkOrder_id { get; set; }

        public Guid fkProduct_id { get; set; }
        #endregion

        #region ForeignKey
        [ForeignKey("fkOrder_id")]
        public OrderProduct? fkOrder { get; set; }

        [ForeignKey("fkProduct_id")]
        public Product? fkProduct { get; set; }
        #endregion


    }
}
