using System.Web.Http;

namespace WebApi
{
    public class HomeController : ApiController
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