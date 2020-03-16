using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Code;
using WorkerService1.Interfaces;
using WorkerService1.Models;
using WorkerService1.Models.Weathers;
using WorkerService2.Models;
using WorkerService2.Models.Weathers;

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

        public async Task<string> GetFiveDaysWeatherApi(string city = "Hanoi")
        {
            using (var client = new HttpClient())
            {
                var uriString = ApiSettings.FiveDaysWeatherForecastApiHostUrl;
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
                    var apiResult = JsonConvert.DeserializeObject<FiveDaysWeatherForecastApiResult>(result);

                    var list = apiResult.list;

                    var cityName = "";
                    cityName = apiResult.city.name;
                    var lonStr = apiResult.city.coord.lon;
                    var latStr = apiResult.city.coord.lat;
                    var countryStr = apiResult.city.country;

                    foreach (var item in list)
                    {
                        var dtUTC = "";
                        dtUTC = item.dt;
                        
                        var dt_txtStr = item.dt_txt;

                        var fiveDaysWeatherData = _context.FiveDaysWeathers.FirstOrDefault(m => m.dt == dtUTC && m.name == cityName && m.lon == lonStr && m.lat == latStr && m.dt_txt == dt_txtStr);

                        if (fiveDaysWeatherData == null)
                        {
                            fiveDaysWeatherData = new FiveDaysWeatherData()
                            {
                                dt = dtUTC,
                                name = cityName,

                                lon = lonStr,
                                lat = latStr,
                                description = item.weather[0].description,
                                icon = item.weather[0].icon,

                                temp = item.main.temp,
                                feels_like = item.main.feels_like,
                                temp_min = item.main.temp_min,
                                temp_max = item.main.temp_max,
                                pressure = item.main.pressure,
                                humidity = item.main.humidity,

                                country = countryStr,

                                dt_txt = dt_txtStr,
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now
                            };

                            await _context.FiveDaysWeathers.AddAsync(fiveDaysWeatherData);
                            await _context.SaveChangesAsync();

                            _logger.LogInformation($"GetFiveDaysWeatherApi --> add FiveDaysWeather {fiveDaysWeatherData.Id}");
                        }
                        else
                        {
                            fiveDaysWeatherData.description = item.weather[0].description;
                            fiveDaysWeatherData.icon = item.weather[0].icon;

                            fiveDaysWeatherData.temp = item.main.temp;
                            fiveDaysWeatherData.feels_like = item.main.feels_like;
                            fiveDaysWeatherData.temp_min = item.main.temp_min;
                            fiveDaysWeatherData.temp_max = item.main.temp_max;
                            fiveDaysWeatherData.pressure = item.main.pressure;
                            fiveDaysWeatherData.humidity = item.main.humidity;

                            fiveDaysWeatherData.DateModified = DateTime.Now;

                            await _context.SaveChangesAsync();

                            _logger.LogInformation($"GetFiveDaysWeatherApi --> update FiveDaysWeather {fiveDaysWeatherData.Id}");
                        }

                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError($"GetFiveDaysWeatherApi --> Error: {ex.Message}");
                }
            }

            return "Success";
        }
    }
}
