using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.WebApi.Domain.Models;

namespace WeatherApp.Services
{
    public class WeatherHttpClientService : IWeatherHttpClientService
    {
        public async Task<HttpResponseMessage> SendRequest(string serviceUrl, string country, string city)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceUrl);
                HttpResponseMessage response = await client.GetAsync($"{country}/{city}");

                return response;
            }
        }

        public async Task<WeatherDetails> GetData(HttpContent httpResponseContent)
        {
            string stringResult = await httpResponseContent.ReadAsStringAsync();
            WeatherDetails weather = JsonConvert.DeserializeObject<WeatherDetails>(stringResult);

            return weather;
        }
    }
}