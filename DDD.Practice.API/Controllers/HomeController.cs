using Microsoft.AspNetCore.Mvc;

namespace DDD.Practice.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
