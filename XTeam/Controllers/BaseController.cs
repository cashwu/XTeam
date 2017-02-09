using System.Web.Mvc;

namespace XTeam.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected bool IsAuth => HttpContext.User.Identity.IsAuthenticated;
    }
}