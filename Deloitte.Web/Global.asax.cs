using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Deloitte.Web.App_Start;
using DryIoc;
using DryIoc.Mvc;

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

            /*  var container = new Container();
              var resolver = new DryIocDependencyResolver(container);
              DependencyResolver.SetResolver(resolver);
              DependenciesConfig.RegisterDependencies();*/

            IContainer container = new Container();
            container = container.WithMvc(
                throwIfUnresolved: type => type.IsController()
            );

            DependenciesConfig.RegisterDependencies(container);
        }
    }
}
