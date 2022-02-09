using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CorrelationService.Interfaces;
using CorrelationService.Models.Settings;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;

namespace CorrelationService.Services
{
   
    public class StockService : IStockService
    {
        private readonly ILogger<StockService> _logger;
        private readonly AppSettings _config;
        private readonly Stocks.StocksClient _client;        
        
        public StockService(ILogger<StockService> logger, AppSettings config){
            _logger = logger;
            _config = config;
            var channel = GrpcChannel.ForAddress(_config.StockServerAddress);
            _client = new Stocks.StocksClient(channel);
        }

        public async Task<StockReply> GetStock(string Name)
        {
            return await _client.GetStockAsync(new StockRequest() { Name = Name });
        }
    }
    

}