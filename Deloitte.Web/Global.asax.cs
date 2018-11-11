using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Deloitte.Web.App_Start;

namespace Deloitte.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependenciesConfig.RegisterDependencies();
        }
    }
}
