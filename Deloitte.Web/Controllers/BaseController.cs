using System.Web.Mvc;
using Deloitte.DAL;

namespace Deloitte.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Logger.Instance.LogAsync(filterContext.Exception)
                .GetAwaiter()
                .GetResult();

            base.OnException(filterContext);
        }
    }
}