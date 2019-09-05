﻿using SittingPlan.Data.Entities;
using SittingPlan.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SittingPlan.Web.Controllers
{
    public class ChairController : ApiController
    {
        public IEnumerable<Chair> Get()
        {
            var repochair = new ChairRepository();
            var getchairs = repochair.GetAll();
            return getchairs;
        }
    }
}
