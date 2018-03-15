namespace WeatherApp.WebApi.Services.Models
{
    /// <summary>
    /// Represents full object from external open weather service
    /// </summary>
    public class OpenWeatherResponse
    {
        public string Name { get; set; }

        public Main Main { get; set; }
    }
}