using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PagosPruebaTuya.V1.Dto.Enumerators.Enumerators;

namespace PagosPruebaTuya.Data.Models
{
    public partial class Address : AudiTableEntity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        #region Contenido
        [Required]
        public string country { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public int city { get; set; }

        [Required, MaxLength(100)]
        public string quarter { get; set; } = string.Empty;

        [Required]
        public EnumStreetType streetType { get; set; }

        [Required, MaxLength(50)]
        public string street { get; set; } = string.Empty;

        [Required, MaxLength(10)]
        public string numberExt { get; set; } = string.Empty;

        [Required, MaxLength(5)]
        public int numberInt { get; set; }

        [Required]
        public bool? state { get; set; } 

        public Guid fkUser_id { get; set; }
        #endregion

        #region ForeignKey
        [ForeignKey("fkUser_id")]
        public User? fkUser { get; set; }
        #endregion

        #region Collection
        public ICollection<OrderProduct>? orders { get; set; }
        #endregion
    }
}
