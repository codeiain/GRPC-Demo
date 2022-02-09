using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;
using WebAPI.Interfaces;
using WebAPI.Models.Settings;

namespace WebAPI.Services
{
    public class CorrelationService : ICorrelationService
    {
        private readonly ILogger<CorrelationService> _logger;
        private AppSettings _config;

        private readonly Correlation.CorrelationClient _client;

        public CorrelationService(ILogger<CorrelationService> logger, AppSettings config)
        {
            _logger = logger;
            _config = config;
            var channel = GrpcChannel.ForAddress(_config.CorrelationServerAddress);
            _client = new Correlation.CorrelationClient(channel);
        }

        public async Task<CorrelationReply> GetData(CorrelationRequest request)
        {
            return await _client.GetWeatherAndStockAsync(request);
        }
    }
}