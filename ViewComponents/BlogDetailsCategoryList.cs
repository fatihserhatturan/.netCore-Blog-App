using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using ErzincanForumApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ErzincanForumApp.ViewComponents
{
    [AllowAnonymous]
    public class BlogDetailsCategoryList : ViewComponent
    {
        CategoryManager categoryManager=new CategoryManager();
        public IViewComponentResult Invoke()
        {
            var categoryList = categoryManager.GetAll();
            return View(categoryList);
        }


    }
}
