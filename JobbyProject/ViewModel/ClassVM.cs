using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobbyProject.Models;

namespace JobbyProject.ViewModel
{
    public class ClassVM
    {
        internal List<User> users;

        public List<Class> classes { get; set; }
        public List<Age> Ages { get; set; }
        public List<Teacher> teachers { get; set; }
        public Teacher teacherFirst { get; set; }
        public List<Blog> blogs { get; set; }
        public List<BlogCateg> blogCategs { get; set; }
        public BlogCateg blogCateg { get; set; }
        public List<GaleryBlog> galeryBlogs { get; set; }
        public List<Adminka> adminkas { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Program> programs { get; set; }


    }
}