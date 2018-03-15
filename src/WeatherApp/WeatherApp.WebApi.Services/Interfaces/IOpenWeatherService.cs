using System.Threading.Tasks;
using WeatherApp.WebApi.Domain.Models;

namespace WeatherApp.WebApi.Services.Interfaces
{
    /// <summary>
    /// Interface for declarions of Web.API weathers' actions
    /// </summary>
    public interface IOpenWeatherService
    {
        Task<WeatherDetails> GetWeather(string country, string city);
    }
}
