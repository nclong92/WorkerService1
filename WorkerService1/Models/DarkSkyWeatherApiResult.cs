using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService2.Models
{
    public class DarkSkyWeatherApiResult
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public Currently currently { get; set; }
        public Hourly hourly { get; set; }
        public Daily daily { get; set; }
    }

    public class Currently
    {
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public double temperature { get; set; }
        public double apparentTemperature { get; set; }
    }

    public class Hourly
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<HourlyData> data { get; set; }
    }

    public class HourlyData
    {
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public double temperature { get; set; }
        public double apparentTemperature { get; set; }

    }

    public class Daily
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<DailyData> data { get; set; }
    }

    public class DailyData
    {
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public double temperatureMin { get; set; }
        public double temperatureMax { get; set; }
    }
}
