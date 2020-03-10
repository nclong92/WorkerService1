using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using WorkerService1.Code;
using WorkerService1.Interfaces;
using WorkerService1.Models;
using WorkerService1.Services;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                using (IServiceScope serviceScope = _serviceProvider.CreateScope())
                {
                    var _httpClientGetOpenWeatherApiService = serviceScope.ServiceProvider.GetRequiredService<IHttpClientGetOpenWeatherApi>();

                    var r = await _httpClientGetOpenWeatherApiService.GetOpenWeatherApi("Hanoi");
                }

                await Task.Delay(1800000, stoppingToken);
            }
        }

    }
}
