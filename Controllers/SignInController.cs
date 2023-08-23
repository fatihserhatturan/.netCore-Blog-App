using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.Controllers
{
    public class SignInController : Controller
    {
        AuthorManager authorManager= new AuthorManager();
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Author A)
        {
            authorManager.AddAuhtor(A);
          return RedirectToAction("AuthorLogin","LogIn");
        }
    }
}
