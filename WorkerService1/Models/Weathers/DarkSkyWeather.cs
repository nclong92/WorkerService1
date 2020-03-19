using System;
using System.Collections.Generic;
using System.Text;
using WorkerService1.Models.Weathers;

namespace WorkerService2.Models.Weathers
{
    public class DarkSkyWeather : EntityBase
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public double precipIntensity { get; set; }
        public double precipProbability { get; set; }
        public string precipType { get; set; }
        public double temperature { get; set; }
        public double apparentTemperature { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double windSpeed { get; set; }
        public double windGust { get; set; }
        public double windBearing { get; set; }
        public double cloudCover { get; set; }
        public double uvIndex { get; set; }
        public double visibility { get; set; }
        public double ozone { get; set; }

        public TodayType Type { get; set; }
    }

    public enum TodayType
    {
        Currently = 0,
        Hourly = 1
    }
}
