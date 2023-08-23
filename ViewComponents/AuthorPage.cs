using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErzincanForumApp.ViewComponents
{
    [AllowAnonymous]
    public class AuthorPage : ViewComponent
    {
        UserProfileManager userprofile = new UserProfileManager();
        public IViewComponentResult Invoke(List<EntityLayer.Concrete.Author> a)
        {
            //var profilevaue = userprofile.GetAuthorByMail();
            return View(a);
        }
    }
}
