using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.Controllers
{
    
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());

        [AllowAnonymous]
        public PartialViewResult CommentList()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult LeaveComment()
        {
            return PartialView();
        }
        public IActionResult CommentListForAdminTrue()
        {
            var commentlist=cm.GetCommentByStatusTrue();
            return View(commentlist);
        }
        public IActionResult StatusChangeToFalse(int id) 
        {
            cm.ChangeCommentStatusToFalse(id);
            return RedirectToAction("CommentListForAdminTrue");
        }
        public IActionResult CommentListForAdminFalse()
        {
            var commentlist = cm.GetCommentByStatusFalse();
            return View(commentlist);
        }
        public IActionResult StatusChangeToTrue(int id)
        {
            cm.ChangeCommentStatusToTrue(id);
            return RedirectToAction("CommentListForAdminFalse");
        }
    }
    
}

