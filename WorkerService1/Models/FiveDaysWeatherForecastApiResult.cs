using System;
using System.Collections.Generic;
using System.Text;
using WorkerService1.Models;

namespace WorkerService2.Models
{
    public class FiveDaysWeatherForecastApiResult
    {
        public string cod { get; set; }
        public List<DayWeatherForecast> list { get; set; }
        public City city { get; set; }
    }

    public class DayWeatherForecast
    {
        public string dt { get; set; }
        public MainResult main { get; set; }
        public List<Weather> weather { get; set; }
        public string dt_txt { get; set; }
    }

    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
    }
}
