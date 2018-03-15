using NSubstitute;
using System.Net.Http;
using WeatherApp.Interfaces;
using WeatherApp.Services;
using WeatherApp.WebApi.Domain.Models;
using WeatherApp.WebApi.Services.Interfaces;
using Xunit;
using Assert = Xunit.Assert;

namespace WeatherApp.Test.Unit
{
    public class BasicUnitTest
    {
        [Fact]
        public async void GetDataFromHttpContentTest()
        {
            //Arrange
            IWeatherHttpClientService weatherHttpClient = new WeatherHttpClientService();

            string json = "{\"location\":{\"city\":\"Warsaw\",\"country\":\"PL\"}," +
                           "\"temperature\":{\"format\":\"Celsius\",\"value\":10.5}," +
                           "\"humidity\":76.0}";

            HttpContent content = new StringContent(json);

            //Act
            WeatherDetails wd = await weatherHttpClient.GetData(content);

            //Assert
            Assert.NotNull(wd);
            Assert.NotNull(wd.Location);
            Assert.NotNull(wd.Temperature);
            Assert.True(wd.Location.City == "Warsaw");
            Assert.True(wd.Location.Country == "PL");
            Assert.True(wd.Temperature.Value == 10.5);
            Assert.True(wd.Humidity == 76);
        }

        [Fact]
        public void LoggerTest()
        {
            //Arrange
            ILogger logger = Substitute.For<ILogger>();
            string errorMsg = "test error message";
            string operationName = "test operation name";

            //Act and Assert
            Assert.NotNull(logger);
            logger.LogError(errorMsg);
            logger.LogSuccess(operationName);
        }
    }
}
