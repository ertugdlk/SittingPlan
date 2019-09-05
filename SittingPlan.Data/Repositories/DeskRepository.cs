using SittingPlan.Data.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SittingPlan.Data.Repositories
{
    public class DeskRepository
    {

        //list of desks
        public List<Desk> GetAll()
        {
            var desks = new List<Desk>();

            //GET REAL DESKS FROM DB WITH ENTITY FRAMEWORK
            using (var sittingPlanContext = new SittingPlanContext())
            {
                desks = sittingPlanContext.Desk.Where(p => p.Id > 0).OrderBy(p => p.Name).Include(p => p.Chairs).ToList();
            }

            return desks;
        }

        //add desk with info
        public void AddDesk(Desk d)
        { 
          
            using (var context = new SittingPlanContext())
            {

                context.Desk.Add(d);
                context.SaveChanges();
            };

        }

        //create empty Desk
        public void AddDesk()
        {
            var desk = new Desk();
            using(var context = new SittingPlanContext())
            {
                context.Desk.Add(desk);
                context.SaveChanges();

            }

        }



    }
}
    

