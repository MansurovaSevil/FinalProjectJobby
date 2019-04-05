using JobbyProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobbyProject.Models;
using JobbyProject.ViewModel;


namespace JobbyProject.Controllers
{
    public class TeacherSingleController : Controller
    {
        private readonly JobbyProjectContext db = new JobbyProjectContext();
        // GET: TeacherSingle
        public ActionResult Index(int id)
        {
            Singleteachers bnm = new Singleteachers();
            bnm.teacher = db.Teachers.Find(id);

            return View(bnm);
        }
    }
}


