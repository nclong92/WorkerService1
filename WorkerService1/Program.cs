using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Configuration;
using WorkerService1.Code;
using WorkerService1.Models;
using Microsoft.EntityFrameworkCore;
using WorkerService1.Interfaces;
using WorkerService1.Services;
using System.IO;

namespace WorkerService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var path = Path.GetDirectoryName(location);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                    //.WriteTo.File("logs/log-{Date}.log")
                    .WriteTo.File($"{path}/logs/log-.log", rollingInterval: RollingInterval.Day)
                    .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    ConfigureServices(services);

                    services.AddHostedService<Worker>();
                })
                .UseSerilog();

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false)
                .Build();
            
            // STATIC VALUE
            ApiSettings.WebApiHostUrl = configuration["WebApiHostUrl"];
            ApiSettings.OpenWeatherApiUri = configuration["OpenWeatherApiUri"];
            ApiSettings.OpenWeatherApiKey = configuration["OpenWeatherApiKey"];
            ApiSettings.FiveDaysWeatherForecastApiHostUrl = configuration["FiveDaysWeatherForecastApiHostUrl"];

            ApiSettings.DarkSkyApiHostUrl = configuration["DarkSkyApiHostUrl"];
            ApiSettings.DarkSkyApiKey = configuration["DarkSkyApiKey"];

            var connectionStrings = configuration.GetConnectionString("AppContext");
            serviceCollection.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(connectionStrings,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });
            });

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton(configuration);

            serviceCollection.AddTransient<AppHost>();

            serviceCollection.AddTransient<IHttpClientGetOpenWeatherApi, HttpClientGetOpenWeatherApi>();
            serviceCollection.BuildServiceProvider();

        }
    }
}
