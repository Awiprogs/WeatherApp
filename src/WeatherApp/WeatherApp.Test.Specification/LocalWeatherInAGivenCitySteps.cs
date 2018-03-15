using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WeatherApp.Interfaces;
using WeatherApp.Services;
using WeatherApp.WebApi.Domain.Models;

namespace WeatherApp.Test.Specification
{
    [Binding]
    public class LocalWeatherInAGivenCitySteps
    {
        private readonly string _appUrl;
        private readonly string _webApiUrl;
        private string _country;
        private string _city;
        private HttpResponseMessage _response;
        private readonly IWeatherHttpClientService _weatherService;

        public LocalWeatherInAGivenCitySteps()
        {
            _weatherService = new WeatherHttpClientService();
            _appUrl = ConfigurationManager.AppSettings["AppUrl"];
            _webApiUrl = ConfigurationManager.AppSettings["WebApiUrl"];
        }

        [Given(@"a webpage with a form")]
        public void GivenAWebpageWithAForm()
        {
            //Check connection to the WeatherApp
            WebRequest request = WebRequest.Create(_appUrl);
            WebResponse response = request.GetResponse();

            if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
            {
                ScenarioContext.Current.Pending();
            }
        }

        [Given(@"I type in '(.*)'")]
        public void GivenITypeIn(string country)
        {
            _country = country;
        }

        [Given(@"I also type in '(.*)'")]
        public void GivenIAlsoTypeIn(string city)
        {
            _city = city;
        }

        [When(@"I submit the form")]
        public async Task WhenISubmitTheForm()
        {
            //Get data from Web.API
            _response = await _weatherService.SendRequest(_webApiUrl, _country, _city);

            if (_response == null || _response.StatusCode != HttpStatusCode.OK)
            {
                ScenarioContext.Current.Pending();
            }
        }

        [Then(@"I receive the temperature and humidity conditions on the day for Warsaw, Poland according to the official weather reports")]
        [Then(@"I receive the temperature and humidity conditions on the day for Gdansk, Poland according to the official weather reports")]
        [Then(@"I receive the temperature and humidity conditions on the day for Berlin, Germany according to the official weather reports")]
        public async void ThenIReceiveTheTemperatureAndHumidityAccordingToTheOfficialWeatherReports()
        {
            //Check result
            WeatherDetails weather = await _weatherService.GetData(_response.Content);

            Assert.IsNotNull(weather);
            Assert.IsNotNull(weather.Temperature);
            Assert.IsNotNull(weather.Location);
            Assert.Equals(weather.Location.Country, _country);
            Assert.Equals(weather.Location.City, _city);
        }
    }
}
