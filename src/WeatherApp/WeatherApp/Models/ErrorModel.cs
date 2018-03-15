namespace WeatherApp.Models
{
    /// <summary>
    /// Model class for Error page
    /// </summary>
    public class ErrorModel
    {
        public WeatherInputModel Input { get; set; }

        public string Message { get; set; }
    }
}