using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace WebApiCore
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