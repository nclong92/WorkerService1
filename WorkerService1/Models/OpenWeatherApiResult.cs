using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService1.Models
{
    public class OpenWeatherApiResult
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public MainResult main { get; set; }
        public Sys sys { get; set; }
        public string name { get; set; }
    }
    
    public class Coord
    {
        public string lon { get; set; }
        public string lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class MainResult
    {
        public string temp { get; set; }
        public string feels_like { get; set; }
        public string temp_min { get; set; }
        public string temp_max { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }
}
