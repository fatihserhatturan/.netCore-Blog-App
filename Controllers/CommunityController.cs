using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace ErzincanForumApp.Controllers
{
    [AllowAnonymous]
    public class CommunityController : Controller
    {

        BlogManager bm = new BlogManager(new EfBlogRepository());
        [AllowAnonymous]
        public IActionResult CommunityIndex()
        {
           
            var blogListCategory = bm.GetBlogListWithCategory();

            return View(blogListCategory);
        }
       
    }
}
