using Microsoft.AspNetCore.Mvc;

namespace Bilet16Trainers.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
