using SittingPlan.Data.Entities;
using SittingPlan.Data.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace SittingPlan.Web.Controllers
{

    public class SittingPlanController : ApiController
    {
        //GET api/sittingplan
        //public IEnumerable<Desk> Get()
        //{
        //    var deskRepository = new DeskRepository();

        //    var desks = deskRepository.GetAll();

        //    return desks;
        //}

        public IEnumerable<Person> Get()
        {
            var p2 = new Person
            {
                Id = 1,
                Name = "ertug ",
                Surname = "dilek",
                Mail = "ertgdl@gmail.com",
            };

            var p = new Person
            {
                Id = 2,
                Name = "beytan ",
                Surname = "kurtulus",
                Mail = "beytan@gmail.com",
            };
            var personrepo = new PersonRepository();         
            var addp = personrepo.AddPersonwithList(p2);
            var deskrepo = new DeskRepository();
            var chairrepo = new ChairRepository();
            chairrepo.AddChairwithPerson();
            deskrepo.AddDesk();

            return addp;
        }

    }
}