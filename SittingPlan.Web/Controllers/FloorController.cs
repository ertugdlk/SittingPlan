﻿using SittingPlan.Data;
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
    public class FloorController : ApiController
    {
        FloorRepository repofloor = new FloorRepository();

        public IEnumerable<Floor> Get()
        {
            return repofloor.GetAll();
        }

        //api/floor/get?floorid={} gets all floor with all information of other entities
        public IEnumerable<Floor> GetAllPlan()
        {
         
            return repofloor.GetPlan(); ;
        }

        //Floor Generate
        [HttpPost]
        public IHttpActionResult Post([FromBody]FloorClass name)
        {
            repofloor.AddFloor(name.Name);
            return Ok();
        }

        public class FloorClass
        {
            public string Name { get; set; }
        }
        
    }
}
