using Microsoft.Extensions.Configuration;
using PagosPruebaTuya.Common.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace PagosPruebaTuya.Test.Common
{
    public class AppSettingFixture: BaseTest, IDisposable
    {
        public void Dispose()
        {
           
        }

        public void Init(string fileAppSetting="")
        {
            if (string.IsNullOrEmpty(fileAppSetting)) fileAppSetting = Constants.FILE_APP_SETTING;
            if (!File.Exists(fileAppSetting)) return;
            Dictionary<string, string> settings = ReadData<Dictionary<string, string>>(fileAppSetting);
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(settings)
                .Build();
            HelperConfiguration.Configuration = configuration;
        }
    }
}
