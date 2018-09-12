using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactDemo.Util
{
    public static class ApplicationSettings
    {
        public static string WebApiUrl { get; set; }
    }
    public class MySettingsModel
    {
        public string WebApiBaseUrl { get; set; }
    }
}
