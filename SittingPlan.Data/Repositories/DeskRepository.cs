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

        public void AddDesk(Desk d)
        { 
          
            using (var context = new SittingPlanContext())
            {

                context.Desk.Add(d);
                context.SaveChanges();
            };

        }




    }
}
    

