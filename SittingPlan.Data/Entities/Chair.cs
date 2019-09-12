using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            public Desk Desk { get; set; }
            [ForeignKey("Id")]
            public virtual ChairPeople StPeople { get; set; }

    }   
}
