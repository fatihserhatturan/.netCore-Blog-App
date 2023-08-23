using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ErzincanForumApp.Controllers
{
    [Authorize]
    
    public class UserController : Controller
    {

        UserProfileManager userprofile = new UserProfileManager();
        AuthorManager authorManager = new AuthorManager();
        BlogManager bm = new BlogManager(new EfBlogRepository());

        
        public IActionResult Index(string p)
        {
            p = HttpContext.Session.GetString("AuthorMail");
            var profilevaue=userprofile.GetAuthorByMail(p);
            return View(profilevaue);
        }
        

        [HttpGet]
        public IActionResult AuthorSettings(string p)
        {
            p = HttpContext.Session.GetString("AuthorMail");
            Context context = new Context();
            int id=context.Authors.Where(x=>x.AuthorMail==p).Select(y=>y.AuthorID).FirstOrDefault();
            var authordata = authorManager.GetDataByAuthor(id);
            return View(authordata);
        }

        
        [HttpPost]
        public IActionResult AuthorSettings(Author p)
        {
            userprofile.UpdateAuthor(p);
            return RedirectToAction("AuthorSettings");
        }
        [HttpGet]
        public IActionResult AuthorImageUpload()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult AuthorImageUpload(AuthorImage b)
        {
            Author p = new Author();
           
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            string a = HttpContext.Session.GetString("AuthorMail");
            Context context = new Context();
            int id = context.Authors.Where(x => x.AuthorMail == a).Select(y => y.AuthorID).FirstOrDefault();
            var authordata = authorManager.GetDataByAuthor(id);
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            foreach (var item in authordata)
            {
                p.AuthorID = item.AuthorID;
                p.AuthorPhoneNumber = item.AuthorPhoneNumber;
                p.AuthorMail = item.AuthorMail;
                p.AuthorName = item.AuthorName;
                p.AuthorPassword = item.AuthorPassword;
                p.AuthorAbout = item.AuthorAbout;
                p.AuthorAboutShort = item.AuthorAboutShort;
                p.AuthorTitle = item.AuthorTitle;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (b.Image != null)
            {
                var extension = Path.GetExtension(b.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                b.Image.CopyTo(stream);
                string newPath = Path.Combine("/images/", newimagename);
                p.AuthorImage = newPath;

            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            userprofile.UpdateAuthor(p);
            return RedirectToAction("AuthorSettings");
        }

        public IActionResult BlogList(string p)
        {
            p = HttpContext.Session.GetString("AuthorMail");
            Context context = new Context();
            int id = context.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogdata= bm.GetBlogByAuthorForAuthor(id);
            return View(blogdata);
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



            Blog blog = bm.FindBLog(id);
            return View(blog);
        }
        [HttpPost]
        
        public IActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("BlogList");
        }
       
        [HttpGet]
        public IActionResult AddNewBlog()
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

            return View();
        }
       
        [HttpPost]
        public IActionResult AddNewBlog(BlogImage b)
        {
            Blog p = new Blog();
            if (b.Image1 != null)
            {
                var extension = Path.GetExtension(b.Image1.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
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
            p.Category = b.Category;
            p.BlogRating = b.BlogRating;
            p.AuthorID = b.AuthorID;
            p.Author = b.Author;
            p.BlogDate = b.BlogDate;
            p.BlogStatus = true;
            bm.BlogAddAdmin(p);

           
            return RedirectToAction("BlogList");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("AuthorLogin","LogIn");
        }

    }
}
