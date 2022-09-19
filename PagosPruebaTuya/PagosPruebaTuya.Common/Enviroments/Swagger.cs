using PagosPruebaTuya.Common.Utils;
using static PagosPruebaTuya.Common.Resources.VariableName;

namespace PagosPruebaTuya.Common.Enviroments
{
    public partial class Variables
    {
        public static class Swagger
        {
            public static string SW_TITLE { get { return HelperConfiguration.GetParam(SW_TITLE_NAME); } }
            public static string SW_DESCRIPTION { get { return HelperConfiguration.GetParam(SW_DESCRIPTION_NAME); } }
            public static string SW_NAME { get { return HelperConfiguration.GetParam(SW_NAME_NAME); } }
            public static string SW_EMAIL { get { return HelperConfiguration.GetParam(SW_EMAIL_NAME); } }
            public static string SW_URL_JSON { get { return HelperConfiguration.GetParam(SW_URL_JSON_NAME); } }
            public static string SW_VERSION { get { return HelperConfiguration.GetParam(SW_VERSION_NAME); } }
        }
    }
}
