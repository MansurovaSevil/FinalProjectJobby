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
    public class HomeController : Controller
    {
        private JobbyProjectContext db = new JobbyProjectContext();
        public ActionResult Index()
        {
            ClassVM bnm = new ClassVM();
            bnm.classes = db.Classes.Take(4).ToList();
            bnm.Ages = db.Ages.ToList();
            bnm.teacherFirst = db.Teachers.First();         
            if (db.Teachers.Count() > 1)
            {
                bnm.teachers = db.Teachers.OrderBy(m=>m.ID).Skip(1).Take(4).ToList();
            }
            else
            {
                bnm.teachers = db.Teachers.ToList();
            }

            bnm.blogs = db.Blogs.Include("adminka").Take(4).ToList();
            bnm.galeryBlogs = db.GaleryBlogs.ToList();
            bnm.blogCategs = db.GetBlogCategs.ToList();
            bnm.adminkas = db.Adminkas.ToList();

            return View(bnm);
            
            
        }

    }
}