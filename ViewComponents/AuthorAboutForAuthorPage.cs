using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.ViewComponents
{
    [AllowAnonymous]
    public class AuthorAboutForAuthorPage : ViewComponent
    {
        AuthorManager am = new AuthorManager();
        public IViewComponentResult Invoke(int id)
        {
            var AuthorAboutList =am.GetAuthorByID(id);
            return View(AuthorAboutList);
        }

    }
}
