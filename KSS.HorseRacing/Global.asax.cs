namespace KSS.HorseRacing
{
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Autofac;
    using Autofac.Integration.Mvc;

    using KSS.HorseRacing.App_Start;
    using KSS.HorseRacing.Infrastucture.DataModels;

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
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());

            builder
                .RegisterAssemblyTypes(
                    Assembly.GetAssembly(typeof(BaseEntity)),
                    Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();

            //builder.RegisterType<InquiryFactory>().As<IInquiryFactory>();

            //builder.RegisterType<AppContext>().As<IAppContext>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}