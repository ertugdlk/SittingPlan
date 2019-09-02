using SittingPlan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SittingPlan.Data.Repositories
{
    public class PersonRepository
    {
        public List<Person> GetAll()
        {
            var people = new List<Person>();

            //GET REAL DESKS FROM DB WITH ENTITY FRAMEWORK
            using (var sittingPlanContext = new SittingPlanContext())
            {
                people = sittingPlanContext.People.Where(p => p.Id > 0).OrderBy(p => p.Name).ToList();
            }

            return people;
        }

        public string AddPerson(Person p)
        {
            using (var personContext = new SittingPlanContext())
            {
                personContext.People.Add(p);
                personContext.SaveChanges();
            }
            return "person created" + p;
        }
    }
}
