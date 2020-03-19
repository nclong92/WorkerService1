using Microsoft.EntityFrameworkCore;
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
using WorkerService2.Code.Helpers;
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

        public async Task<string> GetDarkSkyWeatherApi(string latitude = "21.028511", string longitude = "105.804817")
        {
            var username = "Window Service";

            var apiKey = ApiSettings.DarkSkyApiKey;
            var hostUri = ApiSettings.DarkSkyApiHostUrl;

            var uriString = $"{hostUri}forecast/{apiKey}/{latitude},{longitude}?units=si&lang=vi";

            var responseString = await HttpClientHelpers.GetHttpClientHelper(uriString);

            if (responseString == null)
            {
                _logger.LogError("Error: GetDarkSkyWeatherApi cannot get api result from DarkSky");
            }

            var apiResult = JsonConvert.DeserializeObject<DarkSkyWeatherApiResult>(responseString);

            var latitudeResult = apiResult.latitude;
            var longitudeResult = apiResult.longitude;
            var timezoneResult = apiResult.timezone;

            // DarkSky Current Weathers
            await AddOrUpdateDarkSkyWeather(TodayType.Currently, apiResult.currently.time, latitudeResult, longitudeResult, timezoneResult,
                apiResult.currently.summary, apiResult.currently.icon, apiResult.currently.temperature, apiResult.currently.apparentTemperature, username);

            // DarkSky Hourly Weathers
            var hourlyDatas = apiResult.hourly.data;
            foreach (var hourlyData in hourlyDatas)
            {
                await AddOrUpdateDarkSkyWeather(TodayType.Hourly, hourlyData.time, latitudeResult, longitudeResult, timezoneResult,
                hourlyData.summary, hourlyData.icon, hourlyData.temperature, hourlyData.apparentTemperature, username);
            }

            // DarkSky Daily Weathers
            var dailyData = apiResult.daily.data;
            foreach (var item in dailyData)
            {
                var darkSkyDailyWeather = await _context.DarkSkyDailyWeathers
                                                .FirstOrDefaultAsync(m => m.latitude == latitudeResult && m.longitude == longitudeResult
                                                                    && m.time == item.time);

                if (darkSkyDailyWeather == null)
                {
                    darkSkyDailyWeather = new DarkSkyDailyWeather()
                    {
                        latitude = latitudeResult,
                        longitude = longitudeResult, 
                        timezone = timezoneResult,
                        
                        time = item.time,
                        summary = item.summary,
                        icon = item.icon,
                        temperatureMax = item.temperatureMax,
                        temperatureMin = item.temperatureMin,

                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        UserCreated = username,
                        UserModified = username,
                        
                    };

                    await _context.DarkSkyDailyWeathers.AddAsync(darkSkyDailyWeather);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    darkSkyDailyWeather.time = item.time;
                    darkSkyDailyWeather.summary = item.summary;
                    darkSkyDailyWeather.icon = item.icon;
                    darkSkyDailyWeather.temperatureMax = item.temperatureMax;
                    darkSkyDailyWeather.temperatureMin = item.temperatureMin;

                    darkSkyDailyWeather.DateModified = DateTime.Now;
                    darkSkyDailyWeather.UserModified = username;
                }
            }

            return "Success";
        }


        private async Task AddOrUpdateDarkSkyWeather(TodayType type, long time, double latitude, double longitude, string timezone, string summary,
                                                    string icon, double temperature, double apparentTemperature, string username)
        {
            var darkSkyWeather = await _context.DarkSkyWeathers.FirstOrDefaultAsync(m => m.Type == type
                                                                        && m.time == time
                                                                        && m.latitude == latitude
                                                                        && m.longitude == longitude);

            if (darkSkyWeather == null)
            {
                darkSkyWeather = new DarkSkyWeather()
                {
                    latitude = latitude,
                    longitude = longitude,
                    timezone = timezone,
                    time = time,
                    summary = summary,
                    icon = icon,
                    temperature = temperature,
                    apparentTemperature = apparentTemperature,

                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    UserCreated = username,
                    UserModified = username,

                    Type = type
                };

                await _context.AddAsync(darkSkyWeather);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"GetDarkSkyWeatherApi {type} add new DarkSkyWeather {darkSkyWeather.Id}");
            }
            else
            {
                darkSkyWeather.summary = summary;
                darkSkyWeather.icon = icon;
                darkSkyWeather.temperature = temperature;
                darkSkyWeather.apparentTemperature = apparentTemperature;

                darkSkyWeather.DateModified = DateTime.Now;
                darkSkyWeather.UserModified = username;

                await _context.SaveChangesAsync();

                _logger.LogInformation($"GetDarkSkyWeatherApi {type} update DarkSkyWeather {darkSkyWeather.Id}");
            }
        }
    }
}
