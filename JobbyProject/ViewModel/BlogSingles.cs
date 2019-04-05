using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobbyProject.Models;


namespace JobbyProject.ViewModel
{
    public class BlogSingles
    {
        //internal GaleryBlog galeryBlogsFirst;

        public Blog blog { get; set; }
        public List<Adminka> adminkas { get; set; }
        public List<GaleryBlog> galeryBlogs { get; set; }
        public List<BlogCateg> blogCategs { get; set; }
        public List<Blog> LastBlog { get; set; }
        public List<GaleryBlog> galery2Image { get; set; }
        public List<GaleryBlog> galery3Image { get; set; }
        public List<GaleryBlog> galery4Image { get; set; }
        public List<Comment> comajax { get; set; }
        public List<User> users { get; set; }
    }
}