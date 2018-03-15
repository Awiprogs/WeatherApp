using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using WeatherApp.Interfaces;
using WeatherApp.Services;

namespace WeatherApp
{
    /// <summary>
    /// Autofac configuration file
    /// </summary>
    public class AutofacConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
            RegisterServices(containerBuilder);

            IContainer container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            IWeatherHttpClientService service = new WeatherHttpClientService();

            List<Parameter> parameters = new List<Parameter>
            {
                new NamedParameter("openWeatherHttpService", service),
            };

            containerBuilder.RegisterType<WeatherHttpClientService>().As(typeof(IWeatherHttpClientService)).WithParameters(parameters).InstancePerRequest();
        }
    }
}