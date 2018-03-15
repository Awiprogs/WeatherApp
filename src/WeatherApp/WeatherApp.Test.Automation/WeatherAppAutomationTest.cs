using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;
using System.Threading;

namespace WeatherApp.Test.Automation
{
    [TestClass]
    public class WeatherAppAutomationTest
    {
        protected virtual string ApplicationBaseUrl => ConfigurationManager.AppSettings["MvcAppUrl"];
        protected virtual string CityDomName => "City";
        protected virtual string CountryDomName => "Country";

        /// <summary>
        /// Test application on chrome
        /// </summary>
        [TestMethod]
        [TestCategory("Selenium")]
        [Priority(1)]
        public void WeatherAppChromeTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(ApplicationBaseUrl);

            IWebElement countryElement = driver.FindElement(By.Name(CountryDomName));
            countryElement.SendKeys("Poland");

            Thread.Sleep(2000);

            IWebElement cityElement = driver.FindElement(By.Name(CityDomName));
            cityElement.SendKeys("Warsaw");

            IWebElement buttonShow = driver.FindElement(By.TagName("button"));

            Thread.Sleep(2000);

            buttonShow.Click();
        }

        /// <summary>
        /// Test for firefox may not work, because of the Firefox version and specific settings 
        /// </summary>
        [TestMethod]
        [TestCategory("Selenium")]
        [Priority(2)]
        [Ignore] // Ignores the test below - see the comment above
        public void WeatherAppFirefoxTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(ApplicationBaseUrl);

            IWebElement countryElement = driver.FindElement(By.Name(CountryDomName));
            countryElement.SendKeys("Poland");

            Thread.Sleep(2000);

            IWebElement cityElement = driver.FindElement(By.Name(CityDomName));
            cityElement.SendKeys("Gdansk");

            IWebElement buttonShow = driver.FindElement(By.TagName("button"));

            Thread.Sleep(2000);

            buttonShow.Click();
        }

        /// <summary>
        /// Test for Internet Explorer may not work, because of the IE version and specific settings 
        /// </summary>
        [TestMethod]
        [TestCategory("Selenium")]
        [Priority(3)]
        [Ignore] // Ignores the test below - see the comment above
        public void WeatherAppIETest()
        {
            var options = new InternetExplorerOptions
            {
                InitialBrowserUrl = ApplicationBaseUrl,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                EnableNativeEvents = false,
            };

            IWebDriver driver = new InternetExplorerDriver(options);

            IWebElement countryElement = driver.FindElement(By.Name(CountryDomName));
            countryElement.SendKeys("Germany");

            Thread.Sleep(2000);

            IWebElement cityElement = driver.FindElement(By.Name(CityDomName));
            cityElement.SendKeys("Berlin");

            IWebElement buttonShow = driver.FindElement(By.TagName("button"));

            Thread.Sleep(2000);

            buttonShow.Click();

        }
    }
}
