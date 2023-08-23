using ErzincanForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ErzincanForumApp.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult  CategoryChart()
        {
            List<Class1> list = new List<Class1>();
            list.Add(new Class1
            {
                CategoryName = "Teknoloji",
                BlogCount = 14
            });
            list.Add(new Class1
            {
                CategoryName = "Spor",
                BlogCount = 7
            });
            list.Add(new Class1
            {
                CategoryName = "Kitap",
                BlogCount = 20
            });
            

            return Json(new {jsonlist=list});
        }
    }
}


