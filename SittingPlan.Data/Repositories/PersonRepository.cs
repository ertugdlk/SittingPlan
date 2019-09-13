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
        //list of people
        public List<Person> GetAll()
        {
            var people = new List<Person>();
            //GET REAL PEOPLE FROM DB WITH ENTITY FRAMEWORK
            using (var sittingPlanContext = new SittingPlanContext())
            {
                people = sittingPlanContext.People.Where(p => p.Id > 0).OrderBy(p => p.Name).ToList();
            }
            return people;
        }

        public List<Person> GetNotSittingPeople()
        {
            var people = new List<Person>();
            using (var context = new SittingPlanContext())
            {
                string query = "SELECT* FROM People P WHERE Id NOT IN(SELECT PersonId FROM Chairs C WHERE C.PersonId = P.Id)";
                people = context.Database.SqlQuery<Person>(query).ToList();                           
            }
            return people;
        }

        //add person with return people
        public List<Person> AddPersonwithList(Person p)
        {
            var people = new List<Person>();
            using (var personContext = new SittingPlanContext())
            {
                personContext.People.Add(p);
                personContext.SaveChanges();
                people = personContext.People.Where(x => x.Id > 0).OrderBy(x => x.Name).ToList();
            }
            return people;
        }

        //add person with info
        public void AddPerson(Person p)
        {
            using (var context = new SittingPlanContext())
            {
                context.People.Add(p);
                context.SaveChanges();
            }
        }

        //create person without id
        public void AddPerson(string name, string surname, string mail)
        {
            var p = new Person()
            {
                Name = name,
                Surname = surname,
                Mail = mail
            };
            using (var context = new SittingPlanContext())
            {
                context.People.Add(p);
                context.SaveChanges();
            }
        }
    }
}
