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
        public IEnumerable<Floor> Get()
        {
            var repofloor = new FloorRepository();
            var floors = repofloor.GetAll();
            return floors;

        }

    }
}
