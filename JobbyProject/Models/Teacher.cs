using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Teacher
    {

        public int ID { get; set; }

        [StringLength(250), Required]
        public string Fullname { get; set; }

        [StringLength(255), Required]
        public string Image { get; set; }

        [StringLength(450), Required]
        public string Tittle { get; set; }

        [StringLength(4000), Required]
        public string Description { get; set; }

        [StringLength(200), Required]
        public string Special { get; set; }

        [Required]
        public int Experience { get; set; }

        [StringLength(100), Required]
        public string Phone { get; set; }

        [StringLength(200), Required]
        public string Email { get; set; }

        [StringLength(255), Required]
        public string SliderDesc { get; set; }



        public List<Class> Classes { get; set; }




    }
}