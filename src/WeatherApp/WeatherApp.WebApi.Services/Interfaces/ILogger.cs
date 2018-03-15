namespace WeatherApp.WebApi.Services.Interfaces
{
    /// <summary>
    /// Interface for logging operations
    /// </summary>
    public interface ILogger
    {
        void LogSuccess(string operationName);
        void LogError(string message);
    }
}
