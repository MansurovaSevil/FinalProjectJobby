using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Day
    {
        
        public int ID { get; set; }

        [StringLength(150), Required]
        public string Name { get; set; }

        [Required]
        public int MonthID { get; set; }
        public Month month { get; set; }


        public List<Date> Dates { get; set; }
    }
}