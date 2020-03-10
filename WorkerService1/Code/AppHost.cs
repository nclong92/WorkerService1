using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Interfaces;

namespace WorkerService1.Code
{
    public class AppHost
    {
        private readonly IHttpClientGetOpenWeatherApi _httpClientGetOpenWeatherApi;
        private readonly ILogger<AppHost> _logger;
        static HttpClient client = new HttpClient();

        public AppHost(IHttpClientGetOpenWeatherApi httpClientGetOpenWeatherApi, ILogger<AppHost> logger)
        {
            _httpClientGetOpenWeatherApi = httpClientGetOpenWeatherApi;
            _logger = logger;
        }

        public async Task Run()
        {
            _logger.LogInformation("Run");
            // Removed for brevity
            await _httpClientGetOpenWeatherApi.GetOpenWeatherApi("Hanoi");
        }
    }
}
