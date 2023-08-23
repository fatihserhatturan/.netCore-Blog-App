using Microsoft.AspNetCore.Mvc;

namespace ErzincanForumApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Page403()
        {
            Response.StatusCode = 403;
            HttpContext.Response.Headers["X-StatusCode"] = "403";
            HttpContext.Response.Headers["X-StatusReason"] = "Forbidden";
            HttpContext.Response.Headers["X-ErrorDescription"] = "Custom 403 Forbidden Error";
            return View();
        }
        public IActionResult Page404()
        {
            Response.StatusCode = 404;
            HttpContext.Response.Headers["X-StatusCode"] = "404";
            HttpContext.Response.Headers["X-StatusReason"] = "Forbidden";
            HttpContext.Response.Headers["X-ErrorDescription"] = "Custom 404 Forbidden Error";
            return View();
        }
    }
}
