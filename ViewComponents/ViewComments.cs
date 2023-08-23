using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.ViewComponents
{
    [AllowAnonymous]
    public class ViewComments : ViewComponent
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var CommentList = cm.GetList(id);
            return View(CommentList);
        }

    }
}