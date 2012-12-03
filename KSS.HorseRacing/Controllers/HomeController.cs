using System.Web.Security;

namespace KSS.HorseRacing.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }
    }
}
