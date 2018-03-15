using NSubstitute;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Results;
using WeatherApp.WebApi.Domain.Models;
using WeatherApp.WebApi.Services.Implementations;
using WeatherApp.WebApi.Services.Interfaces;
using WeatherAppWebAPI;
using WeatherAppWebAPI.Controllers;
using Xunit;

namespace WeatherApp.Test.Integration
{
    public class DataTest
    {
        private static readonly WeatherDetailsApiController ApiController;

        static DataTest()
        {
            string apiKey = ConfigurationManager.AppSettings["OpenWeatherApiKey"];
            string openWeatherUrl = ConfigurationManager.AppSettings["OpenWeatherUrl"];
            AutoMapperConfig.Initialize();

            IOpenWeatherService apiService = Substitute.For<OpenWeatherService>(apiKey, openWeatherUrl);
            ILogger logger = Substitute.For<DefaultLogger>();
            ApiController = new WeatherDetailsApiController(apiService, logger);
        }

        [Fact]
        public async void GetWeatherBadRequestTest()
        {
            //Arrange
            string country = "test country";
            string city = "test city";

            //Act
            IHttpActionResult result = await ApiController.GetWeatherDetails(country, city);
            IHttpActionResult res = result as BadRequestErrorMessageResult;

            //Assert
            Assert.True(res != null);
        }

        [Fact]
        public async void GetWeatherTest()
        {
            //Arrange
            string country = "PL";
            string city = "Warsaw";

            //Act
            IHttpActionResult result = await ApiController.GetWeatherDetails(country, city);
            OkNegotiatedContentResult<WeatherDetails> res = result as OkNegotiatedContentResult<WeatherDetails>;

            //Assert
            Assert.True(res != null);
            Assert.True(res.Content.Location.City == city);
        }
    }
}