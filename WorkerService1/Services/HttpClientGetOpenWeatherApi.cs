using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Code;
using WorkerService1.Interfaces;
using WorkerService1.Models;
using WorkerService1.Models.Weathers;

namespace WorkerService1.Services
{
    public class HttpClientGetOpenWeatherApi : IHttpClientGetOpenWeatherApi
    {
        private readonly ILogger<HttpClientGetOpenWeatherApi> _logger;
        private readonly AppDbContext _context;

        public HttpClientGetOpenWeatherApi(ILogger<HttpClientGetOpenWeatherApi> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<string> GetOpenWeatherApi(string city = "Hanoi")
        {
            using (var client = new HttpClient())
            {
                var uriString = ApiSettings.WebApiHostUrl;
                client.BaseAddress = new Uri(uriString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.ConnectionClose = false;
                client.Timeout = TimeSpan.FromMinutes(5);
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(string.Empty),
                                                                Encoding.UTF8,
                                                                "application/json");

                    var apiKey = ApiSettings.OpenWeatherApiKey;
                    var requestUri = $"{uriString}{city}&units=metric&appid={apiKey}";

                    var response = await client.GetAsync(requestUri);

                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    var apiResult = JsonConvert.DeserializeObject<OpenWeatherApiResult>(result);

                    var weatherData = new WeatherData()
                    {
                        name = apiResult.name,
                        lon = apiResult.coord.lon,
                        lat = apiResult.coord.lat,
                        description = apiResult.weather[0].description,
                        icon = apiResult.weather[0].icon,

                        temp = apiResult.main.temp,
                        feels_like = apiResult.main.feels_like,
                        temp_min = apiResult.main.temp_min,
                        temp_max = apiResult.main.temp_max,
                        pressure = apiResult.main.pressure,
                        humidity = apiResult.main.humidity,

                        country = apiResult.sys.country,

                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    };

                    await _context.Weathers.AddAsync(weatherData);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"GetOpenWeatherApi --> add Weather {weatherData.Id}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"GetOpenWeatherApi --> Error: {ex.Message}");
                }
            }

            return "Success";
        }
    }
}
