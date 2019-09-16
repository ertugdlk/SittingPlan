using SittingPlan.Data.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SittingPlan.Data.Repositories
{
    public class DeskRepository
    {
        public List<Desk> GetAll()
        {
            var desks = new List<Desk>();
            using (var sittingPlanContext = new SittingPlanContext())
            {
                desks = sittingPlanContext.Desk.Where(p => p.Id > 0).OrderBy(p => p.Name).ToList();
            }
            return desks;
        }

        public List<Chair> GetChairs(int deskid)
        {
            var chairs = new List<Chair>();
            using (var context  = new SittingPlanContext())
            {
                chairs = context.Chairs.Where(p => p.DeskId == deskid).Include(p=>p.Person).OrderBy(p => p.Id).ToList();
            }
            return chairs;
        }

        public void AddDesk(Desk d)
        {          
            using (var context = new SittingPlanContext())
            {
                context.Desk.Add(d);
                context.SaveChanges();
            };
        }

        public void AddDesk(string name , int floorid)
        {
            var desk = new Desk();
            desk.Name = name;
            desk.FloorId = floorid;
            var floor = new Floor();
            using (var context = new SittingPlanContext())
            {
                context.Desk.Add(desk);
                context.SaveChanges();
            }
        }
    }
}
    

