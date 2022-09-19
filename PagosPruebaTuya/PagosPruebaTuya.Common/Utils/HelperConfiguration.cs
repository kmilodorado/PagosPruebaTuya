using PagosPruebaTuya.Common.Enviroments;
using Microsoft.Extensions.Configuration;

namespace PagosPruebaTuya.Common.Utils
{
    public class HelperConfiguration
    {
        public static IConfiguration? Configuration { get; set; }

        private static string ValidateNom(string key) => !key.Contains(Variables.NAME_CONFIGURATION) ? Variables.NAME_CONFIGURATION + key : key;

        public static string GetParam(string key, bool configution = true)
        {
            key = configution ? ValidateNom(key) : key;
            return Configuration?[key.Trim()] ?? throw new ArgumentException($"Is null {key}");
        }
    }
}
