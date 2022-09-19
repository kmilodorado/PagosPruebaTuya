namespace PagosPruebaTuya.Dto.Config.Common
{
    public class HttpResponseDto<T>
    {

        /// <summary>
        /// Código de la respuesta, obedece a los estadares de HTTPS StatusCode
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Mensaje descriptivo de la respuesta 
        /// </summary>
        public string Descripcion { get; set; } = string.Empty;

        /// <summary>
        /// Objeto esperado por el request dentro de la respuesta 
        /// </summary>
        public T? Objeto { get; set; }
    }
}
