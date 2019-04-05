using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Date
    {

        
        public int ID { get; set; }

        [StringLength(50), Required]
        public string StartTime { get; set; }

        [StringLength(50), Required]
        public string EndTime { get; set; }

        [Required]
        public int DayID { get; set; }
        public Day day { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}