using System.Web.Mvc;

namespace KSS.HorseRacing.Controllers
{
    using System.Web.Security;

    using KSS.HorseRacing.Models;

    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="message">
        /// The message to show on Login page above form.
        /// </param>
        /// <returns>
        /// The System.Web.Mvc.ActionResult.
        /// </returns>
        public ActionResult Login(string message)
        {
            var model = new LoginModel();
            if (!string.IsNullOrWhiteSpace(message))
            {
                model.MessageToShowAbove = message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);

                    if (Url.IsLocalUrl(returnUrl)
                        && returnUrl.Length > 1
                        && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//")
                        && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Dashboard", "Coach");
                }
            }

            ModelState.AddModelError(string.Empty, @"Incorrect login and/or password. Please, try again.");
            return View(model);
        }


        public ActionResult PermissionsError()
        {
            return View();
        }
    }
}
