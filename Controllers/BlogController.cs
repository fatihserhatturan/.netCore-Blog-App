using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using X.PagedList;

namespace ErzincanForumApp.Controllers
{
   // [AllowAnonymous]
    public class BlogController : Controller
    {

        BlogManager bm = new BlogManager(new EfBlogRepository());


        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            //featured post 1
            var posttitle1 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage1 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postdate1 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var postid1 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle1 = posttitle1;
            ViewBag.postimage1 = postimage1;
            ViewBag.postdate1 = postdate1;
            ViewBag.postid1 = postid1;
            //featured post 2
            var posttitle2 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postdate2 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var postid2= bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle2 = posttitle2;
            ViewBag.postimage2 = postimage2;
            ViewBag.postdate2 = postdate2;
            ViewBag.postid2=postid2;
            //featured post 3
            var posttitle3 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postdate3 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var postid3 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle3 = posttitle3;
            ViewBag.postimage3 = postimage3;
            ViewBag.postdate3 = postdate3;
            ViewBag.postid3 = postid3;
            //featured post 4
            var posttitle4 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postdate4 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var postid4 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle4 = posttitle4;
            ViewBag.postimage4 = postimage4;
            ViewBag.postdate4 = postdate4;
            ViewBag.postid4 = postid4;

            //featured post 5
            var posttitle5 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage5 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postdate5 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            var postid5 = bm.GetBlogListWithCategory().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.posttitle5 = posttitle5;
            ViewBag.postimage5 = postimage5;
            ViewBag.postdate5 = postdate5;
            ViewBag.postid5 = postid5;



            var bloglist = bm.GetBlogListWithCategory().ToPagedList(page, 3);
            return View(bloglist);
        }
        [AllowAnonymous]
        public IActionResult BlogDetails(int blogId) 
        {
            return View(blogId); 
        }
        [AllowAnonymous]
        public IActionResult BlogByCategory(int id,int page=1)
        {
            var blogListCategory = bm.GetBlogByCategory(id).ToPagedList(page, 3);
            return View(blogListCategory);
        }

        public IActionResult AdminBlogList()
        {
            var bloglist = bm.GetBlogListWithCategory();
            return View(bloglist);
        }
        public IActionResult AdminBlogList2()
        {
            var bloglist = bm.GetBlogListWithCategoryForAll();
            return View(bloglist);
        }
        [HttpGet]
        public  IActionResult AddNewBlog()
        {
            Context context = new Context();
            List<SelectListItem>values=(from x in context.Categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text=x.CategoryName,
                                            Value=x.CategoryID.ToString()
                                        }).ToList();
            ViewBag.values=values;

            List<SelectListItem> valuesAuthor = (from x in context.Authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();
            ViewBag.valuesAuthor = valuesAuthor;
            return View();
        }

        //public IActionResult AddNewBlog(Blog b)
        //{
        //    bm.BlogAddAdmin(b);
        //    return RedirectToAction("AdminBlogList");
        //}
        [HttpPost]
        public IActionResult AddNewBlog(BlogImage b)
        {
            Blog p = new Blog();
            if (b.Image1 != null)
            {
                var extension = Path.GetExtension(b.Image1.FileName);
                var newimagename=Guid.NewGuid() + extension;
                var location= Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/",newimagename);
                var stream=new FileStream(location,FileMode.Create);
                b.Image1.CopyTo(stream);
                string newPath = Path.Combine("/images/", newimagename);
                p.BlogImage = newPath;

            }
            ///////////////////////////////////////////////////////////////////////////////////////
            if (b.Image2 != null)
            {
                var extension = Path.GetExtension(b.Image2.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.Image2.CopyTo(stream);
                string newPath = Path.Combine("/images/", newimagename);
                p.BlogImage2 = newPath;

            }
            ////////////////////////////////////////////////////////////////////////////////////////
            if (b.Image3 != null)
            {
                var extension = Path.GetExtension(b.Image3.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.Image3.CopyTo(stream);
                string newPath = Path.Combine("/images/", newimagename);
                p.BlogImage3 = newPath;

            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (b.Image4 != null)
            {
                var extension = Path.GetExtension(b.Image4.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.Image4.CopyTo(stream);
                string newPath = Path.Combine("/images/", newimagename);
                p.BlogImage4 = newPath;

            }
            ////////////////////////////////////////////////////////////////////////////////////////
            if (b.Image5 != null)
            {
                var extension = Path.GetExtension(b.Image5.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.Image5.CopyTo(stream);
                string newPath = Path.Combine("/images/", newimagename);
                p.BlogImage5 = newPath;

            }
            ////////////////////////////////////////////////////////////////////////////////////////
            p.BlogContent = b.BlogContent;
            p.BlogTitle = b.BlogTitle;
            p.CategoryID = b.CategoryID;
            p.Category=b.Category;
            p.BlogRating = b.BlogRating;
            p.AuthorID = b.AuthorID;
            p.Author=b.Author;
            p.BlogDate = b.BlogDate;
            p.BlogStatus = true;
            bm.BlogAddAdmin(p);
            return RedirectToAction("AdminBlogList");
        }

        public IActionResult deleteBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("AdminBlogList");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            Context context = new Context();
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> valuesAuthor = (from x in context.Authors.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.AuthorName,
                                                     Value = x.AuthorID.ToString()
                                                 }).ToList();
            ViewBag.valuesAuthor = valuesAuthor;


            Blog blog = bm.FindBLog(id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog p) 
        { 
            bm.UpdateBlog(p);
            return RedirectToAction("AdminBlogList");
        }
        CommentManager cm = new CommentManager(new EFCommentRepository());
        public IActionResult GetCommentForAdmin(int id)
        {
            var CommentList = cm.GetList(id);
            return View(CommentList);
        }

    }
}