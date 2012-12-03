namespace KSS.HorseRacing.Controllers
{
    using System;
    using System.Web.Security;
    using System.Web;
    using System.Web.Mvc;

    using KSS.HorseRacing.Localization;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    FormsAuthentication.SignOut();
            //    return RedirectToAction("Index", "Home");
            //}
            
            return View();
        }

     /*   public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetValidCulture(culture);

            // Save culture in a cookie
            var cookie = Request.Cookies["_culture"];
            if (cookie != null)
            {
                cookie.Value = culture; // update cookie value
            }
            else
            {

                cookie = new HttpCookie("_culture")
                {
                    HttpOnly = false, 
                    Value = culture, 
                    Expires = DateTime.Now.AddYears(1)
                };
            }

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }*/
    }
}
