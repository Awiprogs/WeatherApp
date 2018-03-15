namespace WeatherApp.Models
{
    /// <summary>
    /// Model class for Details page where weather data is presented
    /// </summary>
    public class WeatherDetailsModel : WeatherInputModel
    {
        public string TemperatureFormat { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public bool ShowDetails { get; set; }
    }
}