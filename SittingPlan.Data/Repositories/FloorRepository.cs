﻿using SittingPlan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SittingPlan.Data.Repositories
{
    public class FloorRepository
    {
        public List<Floor> GetAll()
        {
            var floors = new List<Floor>();
            using (var Context = new SittingPlanContext())
            {
                floors = Context.Floors.Where(p => p.Id > 0).OrderBy(p => p.Id).ToList();
            }
            return floors;
        }

        public List<Floor> GetPlan()
        {
            var floors = new List<Floor>();
            using (var Context = new SittingPlanContext())
            {
                floors =  Context.Floors.Include(p => p.Desks.Select(x => x.Chairs.Select(y => y.Person))).ToList();
            }
            return floors;
        }

        public void AddFloor(string name)
        {
            var floor = new Floor()
            {
                Name = name
            };
            using (var context = new SittingPlanContext())
            {
                context.Floors.Add(floor);
                context.SaveChanges();
            }
        }
    }
}
    

