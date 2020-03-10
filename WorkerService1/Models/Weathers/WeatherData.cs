using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService1.Models.Weathers
{
    public class WeatherData : EntityBase
    {
        public string name { get; set; }

        public string lon { get; set; }
        public string lat { get; set; }

        public string description { get; set; }
        public string icon { get; set; }

        public string temp { get; set; }
        public string feels_like { get; set; }
        public string temp_min { get; set; }
        public string temp_max { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }

        public string windspeed { get; set; }
        public string winddeg { get; set; }

        public string country { get; set; }
    }
}
