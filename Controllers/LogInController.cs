using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ErzincanForumApp.Controllers
{
    [AllowAnonymous]
    public class LogInController : Controller
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public LogInController(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        [HttpGet]
        public IActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AuthorLogin(Author p)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Auhtor"),
                new Claim(ClaimTypes.Role,"Author")
            };

            var claimsidentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties=new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsidentity),authProperties);

            Context context = new Context();
            var userinfo=context.Authors.FirstOrDefault(x=>x.AuthorMail == p.AuthorMail && x.AuthorPassword==p.AuthorPassword);

            if (userinfo!=null)
            {
               HttpContext.Session.SetString("AuthorMail",p.AuthorMail);
               return RedirectToAction("AuthorSettings", "User");
            }

            if (!ModelState.IsValid)
            {
                // Hata varsa, işlemin başarısız olduğu bilgisini ViewData üzerinden taşıyalım.
                ViewData["LoginFailed"] = true;
                return View();
            }



            if (userinfo == null)
            {
                ViewData["LoginFailed"] = true;
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin(Admin p)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Admin"),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsidentity), authProperties);


            Context context = new Context();
            var userinfo = context.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);

            if (userinfo != null)
            {
                HttpContext.Session.SetString("UserName", p.UserName);
                return RedirectToAction("AdminBlogList", "Blog");
            }
            if (!ModelState.IsValid)
            {
                // Hata varsa, işlemin başarısız olduğu bilgisini ViewData üzerinden taşıyalım.
                ViewData["LoginFailed"] = true;
                return View();
            }



            if (userinfo == null)
            {
                ViewData["LoginFailed"] = true;
                return View();
            }

            return View();
        }
    }
}
