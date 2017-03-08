using System.Web.Mvc;
using XTeam.Models;

namespace XTeam.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected XTeamEntities Db = new XTeamEntities();

        protected bool IsAuth => HttpContext.User.Identity.IsAuthenticated;

        protected string UserName => HttpContext.User.Identity.Name;

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}