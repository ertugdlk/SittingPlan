using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SittingPlan.Data.Entities
{
    public class ChairPeople
    {
        public int ChairId { get; set; }
        public int PersonId { get; set; }

        [ForeignKey("ChairId")]
        public virtual Chair Chair { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}
