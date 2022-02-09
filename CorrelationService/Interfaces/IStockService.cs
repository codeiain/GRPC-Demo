using System.Threading.Tasks;

namespace CorrelationService.Interfaces
{
    public interface IStockService
    {
        Task<StockReply> GetStock(string Name);
    }
}