using Newtonsoft.Json;

namespace PagosPruebaTuya.Dto.Config.Common
{
    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Atributo { get; set; }
        public string Mensage { get; set; } = string.Empty;
        public ValidationError(string field, string message)
        {
            Atributo = field == string.Empty ? null : field;
            Mensage = message;
        }
    }
}
