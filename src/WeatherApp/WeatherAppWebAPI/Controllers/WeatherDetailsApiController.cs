using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherApp.WebApi.Domain.Models;
using WeatherApp.WebApi.Services.Interfaces;

namespace WeatherAppWebAPI.Controllers
{
    /// <summary>
    /// Weather API controller implementation
    /// </summary>
    [RoutePrefix("api/weather")]
    public class WeatherDetailsApiController : ApiController
    {
        private readonly IOpenWeatherService _openWeatherService;
        private readonly ILogger _logger;

        public WeatherDetailsApiController(IOpenWeatherService webApiService, ILogger logger)
        {
            _openWeatherService = webApiService;
            _logger = logger;
        }

        [Route("{country}/{city}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetWeatherDetails(string country, string city)
        {
            try
            {
                WeatherDetails result = await _openWeatherService.GetWeather(country, city);

                _logger.LogSuccess(nameof(GetWeatherDetails));

                return Ok(result);
            }
            catch (HttpRequestException httpRequestException)
            {
                _logger.LogError(httpRequestException.Message);
                return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
            }
        }
    }
}
