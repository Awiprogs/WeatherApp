namespace WeatherApp.WebApi.Domain.Models
{
    /// <summary>
    /// Represents location for which weather is obtained
    /// </summary>
    public class Location
    {
        public string City { get; set; }

        public string Country { get; set; }
    }
}