using Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace BALHelper
{
    public class MyCustomBAL
    {
        private readonly IConfiguration _configuraiton;
        private readonly MyCustomSettings _myAppSettings;
        //public MyCustomBAL(IConfiguration configuration)
        //{
        //    _configuraiton = configuration;


        //}
        public MyCustomBAL(IOptions<MyCustomSettings> appSettings)
        {
            _myAppSettings = appSettings.Value;
        }
        public String GetConfigValue()
        {
            return _configuraiton["AppSetting"];
        }

        public String GetConfigValue2()
        {
            return _myAppSettings.AppName;
        }
    }
}
