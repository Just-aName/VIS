using VIS.App_Start;
using LightInject;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace VIS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static IServiceContainer IoCContainer;

        protected void Application_Start()
        {
            IoCContainer = new ServiceContainer();

            AreaRegistration.RegisterAllAreas();
            ServiceInstaller.Install(IoCContainer);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
