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
            // user does not authenticated
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (filterContext.HttpContext.Session != null)
                {
                    filterContext.HttpContext.Session.Add("key", "Please login to view that page.");
                }

                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {                        
                        { "controller", "Account" },
                        { "action", "Login" },
                        { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                    });
                return;
            }

            base.OnAuthorization(filterContext);

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
            base.AuthorizeCore(httpContext);

            if (string.IsNullOrWhiteSpace(Roles))
            {
                return true;
            }

            var roles = Roles.Split(',');
            return roles.Any(role => httpContext.User.IsInRole(role));
        }
    }

}
