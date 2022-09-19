using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosPruebaTuya.Dto.V1.Response
{
    public class UserResponseDto
    {
        public Guid codeUser { get; set; }
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}
