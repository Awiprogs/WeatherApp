namespace WeatherApp.WebApi.Domain.Models
{
    /// <summary>
    /// Full domain object representing weather data for a specified location
    /// </summary>
    public class WeatherDetails
    {
        public Location Location { get; set; }
        public Temperature Temperature { get; set; }
        public double Humidity { get; set; }
    }
}