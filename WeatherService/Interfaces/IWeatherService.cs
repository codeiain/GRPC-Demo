using System.Threading.Tasks;
using Grpc.Core;

namespace WeatherService.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherReply> GetWeather(WeatherRequest request, ServerCallContext context);
    }
}