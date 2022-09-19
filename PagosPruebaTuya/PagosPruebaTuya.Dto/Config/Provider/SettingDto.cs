using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosPruebaTuya.Dto.Config.Provider
{
    public class SettingDto
    {
        public string? TokenAuthorization { get; set; }
        public string? OcpApimSubscriptionKey { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}
