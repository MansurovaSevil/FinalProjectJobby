using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobbyProject.Models
{
    public class Blog
    {
        public Blog ()
            
       {
            GaleryBlogs = new List<GaleryBlog>();
            Comments = new List<Comment>();

        }

        public int ID { get; set; }

        [StringLength(255), Required]
        public string Name { get; set; }
        

        [Column(TypeName = "Text")]
        public string BlogDesc1 { get; set; }

        [Column(TypeName = "Text")]
        public string BlogDesc2 { get; set; }

        [Column(TypeName = "Text")]
        public string Title2 { get; set; }

        [Required]
        public int BlogCategID { get; set; }
        public BlogCateg blogCateg { get; set; }

        [Required]
        public int AdminkaID { get; set; }
        public virtual Adminka adminka { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public bool Status { get; set; }



        public List<Comment> Comments { get; set; }

        public List<GaleryBlog> GaleryBlogs { get; set; }

    }
}