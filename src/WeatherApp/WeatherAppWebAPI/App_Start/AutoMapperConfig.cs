using AutoMapper;
using System.Globalization;
using WeatherApp.WebApi.Domain.Models;
using WeatherApp.WebApi.Services.Models;

namespace WeatherAppWebAPI
{
    /// <summary>
    /// Automapper configuration file
    /// </summary>
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
                              {
                                  config.CreateMap<Main, Temperature>()
                                        .ForMember(dest => dest.Format, opt => opt.UseValue(Enums.TemperatureFormat.Celsius))
                                        .ForMember(dest => dest.Value, opt => opt.ResolveUsing(s =>
                                                                                               {
                                                                                                   double temp;
                                                                                                   double.TryParse(s.Temp, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out temp);
                                                                                                   return temp;
                                                                                               }));
                                  config.CreateMap<OpenWeatherResponse, WeatherDetails>()
                                        .ForMember(dest => dest.Humidity, opt => opt.MapFrom(s => s.Main.Humidity))
                                        .ForMember(dest => dest.Temperature, opt => opt.MapFrom(s => s.Main));
                              });
        }
    }
}