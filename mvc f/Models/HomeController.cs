using Microsoft.AspNetCore.Mvc;

namespace mvc_f.Models
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
