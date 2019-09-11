using SittingPlan.Data.Entities;
using SittingPlan.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SittingPlan.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChairController : ApiController
    {
        ChairRepository repochair = new ChairRepository();

        //chairs list
        public IEnumerable<Chair> Get()
        {
            var repochair = new ChairRepository();
            var getchairs = repochair.GetAll();
            return getchairs;
        }

        //generate empty chair on desk post method
        [HttpPost]
        public IHttpActionResult Post([FromBody]ChairClass info)
        {
            repochair.AddEmptyChair(info.DeskId);
            return Ok();
        }

        //Seat person to chair post method
        [HttpPost]
        public IHttpActionResult Seat([FromBody]ChairWithPerson info)
        {
            repochair.addPersontoChair(info.personid, info.chairid );
            return Ok();
        }

        public class ChairWithPerson
        {
            public int chairid { get; set; }
            public int personid { get; set; }
        }

        public class ChairClass
        {
            public int DeskId { get; set; }
        }
    }
}
