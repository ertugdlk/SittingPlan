using SittingPlan.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SittingPlan.Data.Initializers
{
    public class SittingPlanInitializer : DropCreateDatabaseAlways<SittingPlanContext>
    {
        protected override void Seed(SittingPlanContext context)
        {
            var initialDesks = new List<Desk>();

            initialDesks.Add(new Desk
            {
                Id = 1,
                Name = "Dummy Desk 1"
            });

            initialDesks.Add(new Desk
            {
                Id = 2,
                Name = "Dummy Desk 2"
            });

            context.Desk.AddRange(initialDesks);

            base.Seed(context);
        }
    }
}
