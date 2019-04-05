using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Class
    {
        public int ID { get; set; }

        [StringLength(200), Required]
        public string Name  { get; set; }

        [StringLength(255), Required]
        public string Image { get; set; }

        [Required]

        public double Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Required]
        public int SizeSeat { get; set; }

        [DataType(DataType.Time)]
        public DateTime OpenHours { get; set; }

        [DataType(DataType.Time)]
        public DateTime CloseHours { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        public int AgeID { get; set; }
        public Age age { get; set; }

        [Required]
        public int CategoryID { get; set; }
        public Category category { get; set; }

        [Required]
        public int TeacherID { get; set; }
        public Teacher teacher { get; set; }


        public List<Schedule> Schedules { get; set; }


    }
}