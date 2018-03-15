using AutoMapper;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Properties;
using WeatherApp.WebApi.Domain.Models;

namespace WeatherApp.Controllers
{
    /// <summary>
    /// Default Home controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly string _serviceUrl;
        private readonly IWeatherHttpClientService _openWeatherHttpService;

        public HomeController(IWeatherHttpClientService openWeatherHttpService)
        {
            _openWeatherHttpService = openWeatherHttpService;
            _serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"]; ;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            return View(new WeatherInputModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ViewResult> Index(WeatherInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage reponse = await _openWeatherHttpService.SendRequest(_serviceUrl, inputModel.Country, inputModel.City);

                if (reponse.StatusCode == HttpStatusCode.BadRequest)
                {
                    return View("Error", new ErrorModel { Input = inputModel, Message = Resources.InvalidInputData });
                }

                if (!reponse.IsSuccessStatusCode)
                {
                    return View("Error", new ErrorModel { Input = inputModel, Message = Resources.UnexpectedError });
                }

                WeatherDetails weather = await _openWeatherHttpService.GetData(reponse.Content);
                WeatherDetailsModel model = Mapper.Map<WeatherDetailsModel>(weather);
                model.ShowDetails = true;

                return View("Details", model);
            }

            return View(inputModel);
        }
    }




}