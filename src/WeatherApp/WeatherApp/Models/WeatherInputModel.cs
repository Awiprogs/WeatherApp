using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models
{
    /// <summary>
    /// Model class for Home page where input parameters are submitted
    /// </summary>
    public class WeatherInputModel
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }
    }
}