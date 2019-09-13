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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DeskId { get; set; }
        public int? PersonId { get; set; }
        public Desk Desk { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set;}
    }   
}
