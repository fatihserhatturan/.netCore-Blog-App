using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.Controllers
{
    [AllowAnonymous]
    public class MailSubscribeController : Controller
    {
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView("AddMail");
        }
        [HttpPost]
        public IActionResult AddMail(SubscribeMail p)
        {
            SubscribeMailManager subscribeMailManager = new SubscribeMailManager();
            subscribeMailManager.BLAdd(p);
            return RedirectToAction("Index","Blog");
        }
    }
}
