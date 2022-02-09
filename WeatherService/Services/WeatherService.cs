using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using WeatherService.Interfaces;

namespace WeatherService.Services 
{
    public class WeatherService : Weather.WeatherBase, IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(ILogger<WeatherService> logger)
        {
            _logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        

        public override Task<WeatherReply> GetWeather(WeatherRequest request,ServerCallContext context)
        {
            var rng = new Random();

            int index = rng.Next(0, Summaries.Length);
            return Task.FromResult(new WeatherReply() 
            {
                Date = DateTime.UtcNow.ToTimestamp(),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[index]
            });

        }
    }
}