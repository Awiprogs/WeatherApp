using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace WeatherApp.Test.Automation
{
    [TestClass]
    public class WeatherAppJSAutomationTest : WeatherAppAutomationTest
    {
        protected override string ApplicationBaseUrl => ConfigurationManager.AppSettings["AngularAppUrl"];
        protected override string CityDomName => "cityInput";
        protected override string CountryDomName => "countryInput";
    }
}
