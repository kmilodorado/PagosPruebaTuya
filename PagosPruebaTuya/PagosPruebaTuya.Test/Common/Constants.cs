using static PagosPruebaTuya.Test.Common.Resources.DefaultValues;

namespace PagosPruebaTuya.Test.Common
{
    public class Constants
    {
        public static string FILE_APP_SETTING { get{ return FILE_APP_SETTINGS_DEFAULT; } }
        public static string FILE_JSON(string fileJson) {  return string.Format(FILE_JSON_DEFAULT, fileJson); }
        public static string JSON_BUSINESSTEST { get { return FILE_JSON(JSON_BUSINESSTEST_DEFAULT); } }
        public static string JSON_CONTROLLERTEST { get { return FILE_JSON(JSON_CONTROLLERTEST_DEFAULT); } }

    }
}
