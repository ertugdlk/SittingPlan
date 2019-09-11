using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SittingPlan.Data.Entities
{
        public class Chair
        {
            [Key]
            public int Id { get; set; }          
            public int DeskId { get; set; }
            public Person Person { get; set; }
            public Desk Desk { get; set; }
    }   
}
