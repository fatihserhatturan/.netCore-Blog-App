using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.Controllers
{
    public class CommentAddController : Controller
    {
        CommentAddManager commentManager = new CommentAddManager();
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView("AddComment");
        }
        [HttpPost]
        public IActionResult AddComment(Comment p, int blogId)
        {
            p.CommentStatus = true;
            commentManager.CAdd(p);
            return RedirectToAction("BlogDetails", "Blog", new { BlogId = blogId });
        }
    }
}
