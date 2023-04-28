using Microsoft.AspNetCore.Mvc;

namespace WebApiWithoutOwin.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController()
        {
        }

        // Gets
        [HttpGet]
        public string Get(string name)
        {
            return $"hello {name}";
        }
    }
}