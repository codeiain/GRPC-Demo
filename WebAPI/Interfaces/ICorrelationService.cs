using System.Threading.Tasks;

namespace WebAPI.Interfaces
{
    public interface ICorrelationService
    {
        Task<CorrelationReply> GetData(CorrelationRequest request);
    }
}