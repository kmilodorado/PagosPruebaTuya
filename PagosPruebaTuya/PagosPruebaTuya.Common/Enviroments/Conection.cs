using PagosPruebaTuya.Common.Utils;
using static PagosPruebaTuya.Common.Resources.VariableName;

namespace PagosPruebaTuya.Common.Enviroments
{
    public partial class Variables
    {
        public static class Conection
        {
            public static string CONNECTIONSTRINSG_TUYAPAGOSPRUEBATECNICA { get { return HelperConfiguration.GetParam(CONNECTIONSTRINSG_TUYAPAGOSPRUEBATECNICA_NAME); } }
        }
    }
    
}
