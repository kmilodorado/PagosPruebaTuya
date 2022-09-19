using System.ComponentModel.DataAnnotations;

namespace PagosPruebaTuya.Dto.V1.Request
{
    public class ProductOrderRequestDto
    {
        [Required(ErrorMessage = "El {0} es requerido."),
         Display(Name = "Código usuario")]
        public Guid userId { get; set; }

        public List<ProductRequestDto> products { get; set; } = new List<ProductRequestDto>();
    }
}
