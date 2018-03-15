using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.WebApi.Domain.Models;

namespace WeatherApp.Interfaces
{
    public interface IWeatherHttpClientService
    {
        Task<HttpResponseMessage> SendRequest(string serviceUrl, string country, string city);
        Task<WeatherDetails> GetData(HttpContent httpResponseContent);
    }
}