using SittingPlan.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SittingPlan.Data.Repositories
{
    public class DeskRepository
    {
        public List<Desk> GetAll()
        {
            var desks = new List<Desk>();

            //GET REAL DESKS FROM DB WITH ENTITY FRAMEWORK
            using (var sittingPlanContext = new SittingPlanContext())
            {
                desks = sittingPlanContext.Desk.Where(p => p.Id > 0).OrderBy(p => p.Name).ToList();
            }

            return desks;
        }

        public void AddDesk()
        {
            var list = new List<Chair>();
            var num = 1;
            
            using (var context = new SittingPlanContext())
            {
                list.Add(context.Chairs.Find(num));


                var d = new Desk
                {
                    Id = 4,
                    Name = "Desk 2",
                    Chairs = list
                };
                context.Desk.Add(d);
                context.SaveChanges();
            };

        }




    }
}
    

