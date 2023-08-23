using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErzincanForumApp.Controllers
{
    public class AuthorController : Controller
    {
   public PartialViewResult AuthorAbout()
        {
            return PartialView();
        }

        public PartialViewResult AuthorPopularPosts()
        {
            return PartialView();
        }
        BlogManager bm = new BlogManager(new EfBlogRepository());
       [AllowAnonymous]
        public IActionResult AuthorPost(int id)
        {
            var blogListAuthor = bm.GetBlogByAuthor(id);
            return View(blogListAuthor);
        }
        AuthorManager authorManager = new AuthorManager();
        public IActionResult AuthorList()
        {
            var authorList = authorManager.GetAllAuthor();
            return View(authorList);
        }
    }
}
