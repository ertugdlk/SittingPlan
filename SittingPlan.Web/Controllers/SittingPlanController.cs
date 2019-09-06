using SittingPlan.Data.Entities;
using SittingPlan.Data.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace SittingPlan.Web.Controllers
{

    public class SittingPlanController : ApiController
    {

        PersonRepository personrepo = new PersonRepository();

        public IEnumerable<Person> Get()
        {
            var getp = personrepo.GetAll();
            return getp;
        }

        //public IEnumerable<Person> Get(int id)
        //{
        //    var getp = personrepo.GetAll

        //    return getp;

        //}

        [HttpPost]
        public IHttpActionResult Post([FromBody]PersonClass info)
        {
            personrepo.AddPerson(info.Name, info.Surname, info.Mail);
            return Ok(info);
        }

        public class PersonClass{

            public string Name { get; set; }
            public string Surname { get; set; }
            public string Mail { get; set; }



        }


    }
}