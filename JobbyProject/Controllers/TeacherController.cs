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
    public class TeacherController : Controller
    {
        private readonly JobbyProjectContext db = new JobbyProjectContext();

        // GET: Teacher
        public ActionResult Index()
        {
  
            ClassVM bnm = new ClassVM();

            bnm.teachers = db.Teachers.ToList();
            bnm.Ages = db.Ages.ToList();
            return View(bnm);
        }
    }
}