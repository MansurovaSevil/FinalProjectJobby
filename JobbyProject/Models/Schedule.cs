using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Schedule
    {
        public int ID { get; set; }

        [Required]
        public int DateID { get; set; }
        public  Date date { get; set; }

        [Required]
        public int ProgramID { get; set; }
        public Program program { get; set; }

        [Required]
        public int ClassID { get; set; }
        public Class @class { get; set; }
    }
}