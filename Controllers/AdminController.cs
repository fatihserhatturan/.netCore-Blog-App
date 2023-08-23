using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.Controllers
{
    public class AdminController : Controller
    {
        ContactManger cm = new ContactManger();

        public IActionResult SendBox()
        {
            var messagelist = cm.GetAll();
            return View(messagelist);
        }
        public IActionResult MessageDetails(int id) 
        {
            Contact contact= cm.GetContactDetails(id);
            return View(contact);
        }
        public IActionResult AdminLogout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("AdminLogin", "LogIn");
        }
    }
}
