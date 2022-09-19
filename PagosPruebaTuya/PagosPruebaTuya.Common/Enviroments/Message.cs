using PagosPruebaTuya.Common.Utils;
using static PagosPruebaTuya.Common.Resources.VariableName;

namespace PagosPruebaTuya.Common.Enviroments
{
    public partial class Variables
    {
        public static class Message
        {
            public static string SUCCESS_MSG { get { return HelperConfiguration.GetParam(SUCCESS_MSG_NAME); } }
            public static string NOCONTENT_MSG { get { return HelperConfiguration.GetParam(NOCONTENT_MSG_NAME); } }
            public static string ERROR_GENERAL { get { return HelperConfiguration.GetParam(ERROR_GENERAL_NAME); } }
            public static string REQUIEREPRODUCT_MSG { get { return HelperConfiguration.GetParam(REQUIEREPRODUCT_MSG_NAME); } }
            public static string NOCONTENTPROCESS_MSG { get { return HelperConfiguration.GetParam(NOCONTENTPROCESS_MSG_NAME); } }
            
        }
    }
}
