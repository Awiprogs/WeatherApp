namespace WeatherApp.WebApi.Services.Models
{
    /// <summary>
    /// Represents main data from external open weather service
    /// </summary>
    public class Main
    {
        public string Temp { get; set; }
        public double Humidity { get; set; }
    }
}