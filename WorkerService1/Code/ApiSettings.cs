using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService1.Code
{
    public class ApiSettings
    {
        public static string WebApiHostUrl { get; set; }
        public static string FiveDaysWeatherForecastApiHostUrl { get; set; }
        public static string OpenWeatherApiUri { get; set; }
        public static string OpenWeatherApiKey { get; set; }
        public static string DarkSkyApiKey { get; set; }
        public static string DarkSkyApiHostUrl { get; set; }
    }
}
