using SittingPlan.Data;
using SittingPlan.Data.Entities;
using SittingPlan.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SittingPlan.Web.Controllers
{
    public class DeskController : ApiController
    {
        DeskRepository repodesk = new DeskRepository();
        public IEnumerable<Desk> Get()
        {
            var getdesks = repodesk.GetAll();
            return getdesks;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]DeskClass info)
        {
            var floorrepo  = new   FloorRepository();
            repodesk.AddDesk(info.Name , info.FloorId);
            return Ok(info.Name);
        }

        public class DeskClass
        {
            public string Name { get; set; }

            public int FloorId { get; set; }
        }
    }
}
