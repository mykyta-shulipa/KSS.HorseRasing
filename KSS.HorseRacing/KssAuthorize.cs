namespace KSS.HorseRacing
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class KssAuthorize : AuthorizeAttribute
    {
            /// <summary>
        /// The on authorization act.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            // user does not authenticated
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "message", "Please login to view that page." },
                        { "controller", "Account" },
                        { "action", "Login" },
                        { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                    });
                return;
            }

            // user already authenticated, but have not permissions to make action
            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {                            
                        { "controller", "Account" },
                        { "action", "PermissionError" },
                        { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                    });
            }
        }

        /// <summary>
        /// The authorize core.
        /// </summary>
        /// <param name="httpContext">
        /// The http context.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            var roles = Roles.Split(',');

            var isAuthorized = base.AuthorizeCore(httpContext);

            var isAuthenticated = httpContext.User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                if (string.IsNullOrWhiteSpace(Roles))
                {
                    return true;
                }

                return roles.Any(role => httpContext.User.IsInRole(role));
            }

            return false;
        }
    }

    }
}