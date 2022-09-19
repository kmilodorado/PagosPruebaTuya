using System;
using Gen = PagosPruebaTuya.Common.Resources.GenericValuesResource;
namespace PagosPruebaTuya.Common.Enviroments
{
    public partial class Variables : BaseVariables
    {
        public static bool DEBUG { get { return (Environment.GetEnvironmentVariable(Gen.ASPNETCORE_ENVIRONMENT_NAME) ?? "") == "Development"; } }
        public static string NAME_CONFIGURATION {get{ return Gen.NAME_CONFIGURATION; } }
    }
}
