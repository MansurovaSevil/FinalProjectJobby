using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobbyProject.Models;
using JobbyProject.DAL;
using JobbyProject.ViewModel;


namespace JobbyProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly JobbyProjectContext db = new JobbyProjectContext();

        // GET: Blog
        public ActionResult Index()
        {
            ClassVM bnm = new ClassVM();

            bnm.blogs = db.Blogs.ToList();
            bnm.galeryBlogs = db.GaleryBlogs.ToList();
            bnm.blogCategs = db.GetBlogCategs.ToList();
            bnm.adminkas = db.Adminkas.ToList();

            return View(bnm);

        }
        public ActionResult CategBlog (int id)
        {
            ClassVM bnm = new ClassVM();

            bnm.blogCateg = db.GetBlogCategs.Find(id);
            bnm.blogs = db.Blogs.Where(m => m.blogCateg.ID == id).ToList();
            bnm.galeryBlogs = db.GaleryBlogs.ToList();
            bnm.adminkas = db.Adminkas.ToList();

            return View(bnm);
        }
    }
}