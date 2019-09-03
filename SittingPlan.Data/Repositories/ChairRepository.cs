using SittingPlan.Data.Entities;
using System;
using System.Collections.Generic;
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

            //GET REAL DESKS FROM DB WITH ENTITY FRAMEWORK
            using (var context = new SittingPlanContext())
            {
                chairs = context.Chairs.Where(x => x.Id > 0).OrderBy(x => x.Person.Name).ToList();
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

        //empty chair add
        public void AddEmptyChair()
        {
            var chair = new Chair();

            using (var context = new SittingPlanContext())
            {
                context.Chairs.Add(chair);
                context.SaveChanges();
            }
        }


        //add person to chair
        public void addPersontoChair(Person person , Chair c)
        {
            using (var context = new SittingPlanContext())
            {
                var chair = context.Chairs.Find(c.Id);
                chair.Person = person;
                context.SaveChanges();
            }

                

        }



    }
}
