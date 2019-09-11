using SittingPlan.Data.Entities;
using SittingPlan.Data.Repositories;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SittingPlan.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : ApiController
    {
        PersonRepository personrepo = new PersonRepository();

        //People list
        public IEnumerable<Person> Get()
        {
            var getp = personrepo.GetAll();
            return getp;
        }

        //Person Generate
        [HttpPost]
        public IHttpActionResult Post([FromBody]PersonClass info)
        {
            personrepo.AddPerson(info.Name, info.Surname, info.Mail);
            return Ok();
        }

        public class PersonClass{
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Mail { get; set; }
        }
    }
}