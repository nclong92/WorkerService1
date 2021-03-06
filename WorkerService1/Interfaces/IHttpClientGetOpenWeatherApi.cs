﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Interfaces
{
    public interface IHttpClientGetOpenWeatherApi
    {
        Task<string> GetOpenWeatherApi(string city);
        Task<string> GetFiveDaysWeatherApi(string city);
        Task<string> GetDarkSkyWeatherApi(string latitude, string longitude);
    }
}
