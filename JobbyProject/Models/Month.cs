using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Month
    {
        public int ID { get; set; }

        [StringLength(150), Required]
        public string Name { get; set; }

        public List<Day> Days { get; set; }
    }
}