using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Category
    {
        public int ID { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }

        public List<Class> Classes { get; set; }


    }

}