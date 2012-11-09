namespace KSS.HorseRacing
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using KSS.HorseRacing.App_Start;
    using KSS.HorseRacing.Infrastucture;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundlesConfig.RegisterBundles(BundleTable.Bundles);

            SetDependencyResolver();
        }

        private void SetDependencyResolver()
        {
            IoC.Build();
        }
    }
}