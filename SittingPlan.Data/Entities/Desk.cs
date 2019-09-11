using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SittingPlan.Data.Entities
{
    public class Desk
    {
        [Key]
        public int Id { get; set; }        
        public int FloorId { get; set; }
        public string Name { get; set; }
        public List<Chair> Chairs { get; set; }
        public Floor Floor { get; set; }
    }   
}
