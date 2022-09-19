namespace PagosPruebaTuya.Dto.Config.Common
{
    public class HttpResponseErrorDto : HttpResponseGenericDto
    {
        /// <summary>
        /// Mensaje descriptivo de la respuesta 
        /// </summary>
        public string Mensaje { get; set; } = string.Empty;

        /// <summary>
        /// Objeto esperado por el request dentro de la respuesta 
        /// </summary>
        public string Detalle { get; set; } = string.Empty;
    }
}
