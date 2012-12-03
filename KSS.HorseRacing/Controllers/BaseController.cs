namespace KSS.HorseRacing.Controllers
{
    using System.Globalization;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;

    using KSS.HorseRacing.Localization;

    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // Is it View ?
            ViewResultBase view = filterContext.Result as ViewResultBase;
            if (view == null)
            {
                // if not exit
                return;
            }

            var cultureName = Thread.CurrentThread.CurrentCulture.Name; // e.g. "en-US" // filterContext.HttpContext.Request.UserLanguages[0]; // needs validation return "en-us" as default            

            // Is it default culture? exit
            if (cultureName == CultureHelper.GetDefaultCulture())
            {
                return;
            }

            // Are views implemented separately for this culture?  if not exit
            var viewImplemented = CultureHelper.IsViewSeparate(cultureName);
            if (viewImplemented == false)
            {
                return;
            }

            var viewName = view.ViewName;

            int i;

            if (string.IsNullOrEmpty(viewName))
            {
                viewName = filterContext.RouteData.Values["action"] + "." + cultureName; // Index.en-US}
            }
            else if ((i = viewName.IndexOf('.')) > 0)
            {
                // contains . like "Index.cshtml"                
                viewName = viewName.Substring(0, i + 1) + cultureName + viewName.Substring(i);
            }
            else viewName += "." + cultureName; // e.g. "Index" ==> "Index.en-Us"

            view.ViewName = viewName;

            filterContext.Controller.ViewBag._culture = "." + cultureName;

            base.OnActionExecuted(filterContext);
        }


        protected override void ExecuteCore()
        {
            string cultureName = null;
            // Attempt to read the culture cookie from Request
            var cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                if (Request.UserLanguages != null)
                {
                    cultureName = Request.UserLanguages[0]; // obtain it from HTTP header AcceptLanguages
                }
            }

            // Validate culture name
            cultureName = CultureHelper.GetValidCulture(cultureName); // This is safe

            // Modify current thread's culture            
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);

            base.ExecuteCore();
        }

    }
}
