using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.ViewComponents
{
    [AllowAnonymous]
    public class Footer : ViewComponent
    {
        AboutManager aboutManager = new AboutManager();
        public IViewComponentResult Invoke()
        {
          var aboutcontentlist =  aboutManager.GetAll();
            return View(aboutcontentlist);
        }
      
    }
}