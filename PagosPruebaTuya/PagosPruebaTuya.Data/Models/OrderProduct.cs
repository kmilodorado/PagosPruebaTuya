using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PagosPruebaTuya.V1.Dto.Enumerators.Enumerators;

namespace PagosPruebaTuya.Data.Models
{
    public partial class OrderProduct : AudiTableEntity
    {
        [Key]
        public Guid id { get; set; }

        #region Contenido

        [Required]
        public EnumStateOrden stateOrden { get; set; } = 0;
        [Required]
        public decimal price { get; set; } = 0;

        public Guid fkUser_id { get; set; }

        public int fkAddress_id { get; set; }

        public int? fkPaymentMethod_id { get; set; }
        #endregion

        #region ForeignKey
        [ForeignKey("fkUser_id")]
        public User? fkUser { get; set; }

        [ForeignKey("fkAddress_id")]
        public Address? fkAddress { get; set; }

        [ForeignKey("fkPaymentMethod_id")]
        public PaymentMethod? fkPaymentMethod { get; set; }
        #endregion

        #region Collection
        public ICollection<DetailOrder>? detailOrders { get; set; }
        #endregion
    }
}
