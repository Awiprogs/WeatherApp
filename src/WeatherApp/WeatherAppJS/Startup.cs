using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeatherAppJS.Startup))]
namespace WeatherAppJS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
