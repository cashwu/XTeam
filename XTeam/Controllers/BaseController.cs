using System.Web.Mvc;
using XTeam.Models;

namespace XTeam.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected bool IsAuth => HttpContext.User.Identity.IsAuthenticated;

        protected XTeamEntities Db => new XTeamEntities();
    }
}