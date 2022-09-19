using System.ComponentModel.DataAnnotations;

namespace PagosPruebaTuya.Dto.V1.Request
{
    public class ProductRequestDto
    {
        [Required(ErrorMessage = "El {0} es requerido."),
        Display(Name = "Código producto")]
        public Guid productId { get; set; }

        [Required(ErrorMessage = "El {0} es requerido."),
        Display(Name = "Cantidad")]
        public int quantity { get; set; } = 0;
    }
}
