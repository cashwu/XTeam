using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XTeam.Models;

namespace XTeam.Controllers.Api
{
    public class ScriptApiController : ApiController
    {
        private XTeamEntities db = new XTeamEntities();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(db.Scripts.ToList());
        }
    }
}
