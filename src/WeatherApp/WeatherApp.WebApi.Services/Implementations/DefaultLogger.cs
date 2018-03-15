using System;
using WeatherApp.WebApi.Services.Interfaces;
using WeatherApp.WebApi.Services.Properties;

namespace WeatherApp.WebApi.Services.Implementations
{
    /// <summary>
    /// Default logger implementation
    /// </summary>
    public class DefaultLogger : ILogger
    {
        public void LogSuccess(string message)
        {
            Console.WriteLine($@"{Resources.Success} - {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($@"{Resources.Fail} - {message}");
        }
    }
}
