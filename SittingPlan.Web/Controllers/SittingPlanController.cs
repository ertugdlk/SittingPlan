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
            var personrepo = new PersonRepository();         
            var getp = personrepo.GetAll();
            var deskrepo = new DeskRepository();
            var chairrepo = new ChairRepository();
            //chairrepo.AddChairwithPerson();
            //deskrepo.AddDesk();

            return getp;
        }

    }
}