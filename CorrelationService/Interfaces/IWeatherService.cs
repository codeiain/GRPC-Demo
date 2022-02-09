using System.Threading.Tasks;
using Grpc.Core;

namespace CorrelationService.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherReply> GetWeather(string location);
    }
}