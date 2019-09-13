using SittingPlan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SittingPlan.Data.Repositories
{
    public class ChairRepository
    {
        //list of chairs
        public List<Chair> GetAll()
        {
            var chairs = new List<Chair>();
            using (var context = new SittingPlanContext())
            {
                chairs = context.Chairs.Where(x => x.Id > 0).Include(p=> p.Person).OrderBy(x => x.Person.Id).ToList();
            }
            return chairs;
        }

        //add chair with information
        public  void AddChair(Chair c)
        {
            using (var context = new SittingPlanContext())
            {
                context.Chairs.Add(c);
                context.SaveChanges();
            };
        }

        //empty chair with deskid
        public void AddEmptyChair(int deskId)
        {
            var chair = new Chair();
            chair.DeskId = deskId;
            using (var context = new SittingPlanContext())
            {
                context.Chairs.Add(chair);
                context.SaveChanges();
            }
        }

        public void removePersontoChair(int chairid)
        {
            using (var context = new SittingPlanContext())
            {
                var chair = context.Chairs.Find(chairid);
                chair.PersonId = null;
                chair.Person = null;
                context.SaveChanges();
            }

        }

        //add person to chair
        public void addPersontoChair(int personid , int chairid)
        {
            using (var context = new SittingPlanContext())
            {
                var chair = context.Chairs.Find(chairid);
                var person = context.People.Find(personid);
                chair.PersonId = personid;
                chair.Person = person;
                context.SaveChanges();
            }
        }
    }
}
