using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManger cm= new ContactManger();
      
        [HttpGet] 
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContact(Contact p)
        {
            cm.ContactAdd(p);
            return View();
        }
    }
}
