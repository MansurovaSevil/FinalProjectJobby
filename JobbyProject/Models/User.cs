using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class User
    {
        public int ID { get; set; }

        [StringLength(250), Required]
        public string Fullname { get; set; }

        [StringLength(150), Required]
        public string Email { get; set; }

        [StringLength(255), Required]
        public string Password { get; set; }

        
        public string Image { get; set; }

        public List<Comment> Comments { get; set; }
    }
}