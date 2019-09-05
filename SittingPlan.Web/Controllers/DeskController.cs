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

        public IEnumerable<Desk> Get()
        {
            var repodesk = new DeskRepository();
            var getdesks = repodesk.GetAll();
            return getdesks;
        }
    }
}
