using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace StockService.Services
{
    public class StockService : Stocks.StocksBase
    {
        private readonly ILogger<StockService> _logger;

        public StockService(ILogger<StockService> logger)
        {
            _logger = logger;
        }

        public override Task<StockReply> GetStock(StockRequest request, ServerCallContext context)
        {
            return Task.FromResult(new StockReply()
            {
                Name = "Stock1",
                Value = 30
            });
        }
        
    }
}