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
    public class FloorController : ApiController
    {
        FloorRepository repofloor = new FloorRepository();

        public IEnumerable<Floor> Get()
        {
            return repofloor.GetAll();
        }

        public void Post([FromBody] Floor floor)
        {
            repofloor.AddFloor(floor.Name);     
        }

    }
}
