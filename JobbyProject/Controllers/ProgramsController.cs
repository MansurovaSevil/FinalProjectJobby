using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobbyProject.DAL;
using JobbyProject.ViewModel;
using JobbyProject.Models;

namespace JobbyProject.Controllers
{
    public class ProgramsController : Controller
    {

        private readonly JobbyProjectContext db = new JobbyProjectContext();
        // GET: Programs
        public ActionResult Index()
        {
            ClassVM bnm = new ClassVM();
            bnm.programs = db.Programs.ToList();
                
            return View();
        }
    }
}