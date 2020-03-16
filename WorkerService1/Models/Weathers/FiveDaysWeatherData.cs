using System;
using System.Collections.Generic;
using System.Text;
using WorkerService1.Models.Weathers;

namespace WorkerService2.Models.Weathers
{
    public class FiveDaysWeatherData : EntityBase
    {
        public string dt { get; set; }
        public string dt_txt { get; set; }
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
