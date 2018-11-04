using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        public ActionResult PageNotFound()
        {
            return View("PageNotFound");
        }
    }
}