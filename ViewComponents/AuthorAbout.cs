using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.ViewComponents
{
    [AllowAnonymous]
    public class AuthorAbout : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return View(BlogDetailsList);
        }

    }
}
