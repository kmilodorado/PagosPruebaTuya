using Newtonsoft.Json;
using PagosPruebaTuya.Test.Common;
using System.IO;

namespace PagosPruebaTuya.Test
{
    public class BaseTest
    {
        public BaseTest() { }

        public AppSettingFixture CrearteAppSettingsFixture()
        {
            return new AppSettingFixture();
        }

        public TData ReadData<TData>(string filePath) where TData : class
        {
            string fileRead = File.ReadAllText(filePath);
            TData dataMock= JsonConvert.DeserializeObject<TData>(fileRead);
            return dataMock;
        }
    }
}
