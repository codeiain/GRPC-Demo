using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CorrelationService.Interfaces;
using CorrelationService.Models.Settings;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;

namespace CorrelationService.Services
{
   
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;
        private readonly AppSettings _config;
        private readonly Weather.WeatherClient _client;        
        
        public WeatherService(ILogger<WeatherService> logger, AppSettings config){
            _logger = logger;
            _config = config;
            var channel = GrpcChannel.ForAddress(_config.WeatherServerAddress);
            _client = new Weather.WeatherClient(channel);
        }

        public async Task<WeatherReply> GetWeather(string location)
        {
            return await _client.GetWeatherAsync(new WeatherRequest() { Location = location });
        }
    }
    

}