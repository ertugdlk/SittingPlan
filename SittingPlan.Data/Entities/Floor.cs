using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SittingPlan.Data.Entities
{
    public class Floor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Desk> Desks { get; set; }

        public Floor()
        {
            Desks = new List<Desk>();
        }
    }
    
}
