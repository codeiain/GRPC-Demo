using System.Threading.Tasks;
using CorrelationService.Interfaces;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace CorrelationService.Services
{
    public class CorrelationService : Correlation.CorrelationBase
    {
        private readonly ILogger<CorrelationService> _logger;
        private readonly IStockService _stockService;
        private readonly IWeatherService _weatherService;

        public CorrelationService(ILogger<CorrelationService> logger, IStockService stockService, IWeatherService weatherService)
        {
            _logger = logger;
            _stockService = stockService;
            _weatherService = weatherService;
        }

        public override async Task<CorrelationReply> GetWeatherAndStock(CorrelationRequest request, ServerCallContext context)
        {
            var weather = await _weatherService.GetWeather("nothing");
            var stock = await _stockService.GetStock("nothing");
            return new CorrelationReply()
            {
                Weather = weather,
                Stock = stock
            };
        }
        
    }
}