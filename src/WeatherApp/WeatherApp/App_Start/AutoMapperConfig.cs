using AutoMapper;
using WeatherApp.Models;
using WeatherApp.WebApi.Domain.Models;

namespace WeatherApp
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
                              {
                                  config.CreateMap<WeatherDetails, WeatherDetailsModel>()
                                        .ForMember(dest => dest.TemperatureFormat, opt => opt.MapFrom(s => s.Temperature.Format.ToString()))
                                        .ForMember(dest => dest.Temperature, opt => opt.MapFrom(s => s.Temperature.Value))
                                        .ForMember(dest => dest.City, opt => opt.MapFrom(s => s.Location.City))
                                        .ForMember(dest => dest.Country, opt => opt.MapFrom(s => s.Location.Country));
                              });
        }
    }
}