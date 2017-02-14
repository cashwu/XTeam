using System.Linq;
using System.Web.Http;
using XTeam.Models;

namespace XTeam.Controllers.Api
{
    public class ScriptApiController : ApiController
    {
        private readonly XTeamEntities db = new XTeamEntities();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(db.Scripts.ToList());
        }

        [HttpGet]
        public IHttpActionResult GetScriptName()
        {
            return Ok(db.Scripts.Select(a => new 
            {
                Id = a.Id,
                Name = a.Name
            }));
        }

        [HttpGet]
        public IHttpActionResult GetScriptById([FromUri]int id)
        {
            var script = db.Scripts.FirstOrDefault(a => a.Id == id);
            return Ok(script);
        }
    }
}
