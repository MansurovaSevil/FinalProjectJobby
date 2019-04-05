using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Comment
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int UserID { get; set; }
        public User user { get; set; }

        [Required]
        public int BlogID { get; set; }
        public Blog blog { get; set; }
    }
}