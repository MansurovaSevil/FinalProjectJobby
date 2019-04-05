using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class BlogCateg
    {
        public int ID { get; set; }

        [StringLength(150), Required]
        public string Name { get; set; }

        public List<Blog>Blogs { get; set; }

    }
}