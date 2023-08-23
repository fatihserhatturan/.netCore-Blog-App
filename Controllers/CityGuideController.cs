using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.Controllers
{
    public class CityGuideController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
