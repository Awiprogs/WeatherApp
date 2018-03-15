using System.Web.Mvc;

namespace WeatherAppJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}