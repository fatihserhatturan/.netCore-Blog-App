using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager();
        [AllowAnonymous]
        public IActionResult Index()
        {
          var about=  aboutManager.GetAll();
            return View(about);
        }
        [AllowAnonymous]
        public PartialViewResult Footer()
        {
            aboutManager.GetAll();
            return PartialView(aboutManager);
        }
        [HttpGet]
        public IActionResult UpdateAboutList()
        {
            var about = aboutManager.GetAll();
            return View(about);

        }
        [HttpPost]
        public IActionResult UpdateAbout(About P)
        {
            aboutManager.UpdateAbout(P);
            return RedirectToAction("UpdateAboutList");

        }


    }
}
