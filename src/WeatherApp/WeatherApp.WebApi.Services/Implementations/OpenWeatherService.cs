using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.WebApi.Domain.Models;
using WeatherApp.WebApi.Services.Interfaces;
using WeatherApp.WebApi.Services.Models;

namespace WeatherApp.WebApi.Services.Implementations
{
    /// <summary>
    /// Delivers data from external open weather service
    /// </summary>
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly string _openWeatherUrl;
        private readonly string _apiKey;

        public OpenWeatherService(string apiKey, string openWeatherUrl)
        {
            _apiKey = apiKey;
            _openWeatherUrl = openWeatherUrl;
        }

        public async Task<WeatherDetails> GetWeather(string country, string city)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_openWeatherUrl);
                HttpResponseMessage response = await client.GetAsync($"data/2.5/weather?q={city},{country}&appid={_apiKey}&units=metric");
                response.EnsureSuccessStatusCode();

                string stringResult = await response.Content.ReadAsStringAsync();
                OpenWeatherResponse weather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);

                WeatherDetails wd = Mapper.Map<WeatherDetails>(weather);
                wd.Location = new Location { City = city, Country = country };

                return wd;
            }
        }
    }
}
