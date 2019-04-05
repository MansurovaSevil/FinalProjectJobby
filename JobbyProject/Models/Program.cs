using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Program
    {
        public int ID { get; set; }

        [StringLength(150), Required]
        public string Name { get; set; }

        [StringLength(255), Required]
        public string IconImg { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

     

        public List<Schedule> Schedules { get; set; }
    }
}