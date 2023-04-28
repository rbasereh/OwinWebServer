using Microsoft.AspNetCore.Mvc;

namespace WebApiWithoutOwin.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet]
        public string Index()
        {
            return "Index";
        }

        [HttpGet]
        public string SayHello(string name)
        {
            return $"hi {name}";
        }
    }
}