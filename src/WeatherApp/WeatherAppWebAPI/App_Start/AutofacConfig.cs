using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using WeatherApp.WebApi.Services.Implementations;
using WeatherApp.WebApi.Services.Interfaces;

namespace WeatherAppWebAPI
{
    /// <summary>
    /// Autofac configuration file
    /// </summary>
    public class AutofacConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterServices(containerBuilder);

            IContainer container = containerBuilder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }


        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            string openWeatherApiKey = ConfigurationManager.AppSettings["OpenWeatherApiKey"];
            string openWeatherUrl = ConfigurationManager.AppSettings["OpenWeatherUrl"];

            List<Parameter> parameters = new List<Parameter>
            {
                new NamedParameter("apiKey", openWeatherApiKey),
                new NamedParameter("openWeatherUrl", openWeatherUrl),
            };

            containerBuilder.RegisterType<OpenWeatherService>().As<IOpenWeatherService>().WithParameters(parameters).InstancePerRequest();
            containerBuilder.RegisterType<DefaultLogger>().As<ILogger>().InstancePerRequest();
        }
    }
}