namespace WeatherApp.WebApi.Domain.Models
{
    /// <summary>
    /// Represents temperature data
    /// </summary>
    public class Temperature
    {
        public Enums.TemperatureFormat Format { get; set; }

        public double Value { get; set; }
    }
}