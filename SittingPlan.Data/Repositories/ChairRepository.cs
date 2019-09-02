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

        public  void AddChair()
        {
            using (var context = new SittingPlanContext())
            {
                var p = context.People.FirstOrDefault();
                var d = context.Desk.FirstOrDefault();

                var c = new Chair
                {
                    Id = 1,
                    Person = p,
                    

                };

                var c2 = new Chair
                {
                    Id = 2,
                    Person = p,

                };

                context.Chairs.Add(c);
                context.SaveChanges();
            };

        }

    }
}
