using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class GaleryBlog
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string ImageBlog { get; set; }

        [Required]
        public int BlogID { get; set; }
        public Blog blog { get; set; }

    }
}