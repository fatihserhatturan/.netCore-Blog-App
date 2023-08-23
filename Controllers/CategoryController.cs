using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm= new CategoryManager();
        [AllowAnonymous]
        public IActionResult Index()
        {
            var categoryvalues=cm.GetAll();
            return View(categoryvalues);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            return PartialView();
        }
        public IActionResult AdminCategoryList()
        {
            var categoryLİst=cm.GetAll();
            return View(categoryLİst);
        }
        [HttpGet]
        public IActionResult AdminAddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminAddCategory(Category p)
        {
            cm.categoryAdd(p);
            return RedirectToAction("AdminCategoryList", "Category");
        }
    }
}
