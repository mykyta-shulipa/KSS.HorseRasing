namespace KSS.HorseRacing
{
    using System.Globalization;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using KSS.HorseRacing.App_Start;
    using KSS.HorseRacing.Configuration;

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

            setDependencyResolver();

            // Create culture info object 
            var ci = new CultureInfo("en");
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }

        private void setDependencyResolver()
        {
            WebDiConfig.Register();
            ControllerBuilder.Current.SetControllerFactory(typeof(UnityControllerFactory));            
        }
    }
}