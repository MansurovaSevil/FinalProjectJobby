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
    public class ClassesSingleController : Controller
    {

        private readonly JobbyProjectContext db = new JobbyProjectContext();
        // GET: ClassesSingle
        public ActionResult Index(int id)
        {

           
        ClassSingle bnm = new ClassSingle();
         
            bnm.classes= db.Classes.Find(id);
            bnm.teachers = db.Teachers.ToList();
            bnm.Ages = db.Ages.ToList();
            bnm.clasr = db.Classes.ToList();
            

          
            return View(bnm);
            
        }

        //public ActionResult Index1()
        //{
        //    ClassVM bnm = new ClassVM();


        //    bnm.classes = db.Classes.ToList();
        //    bnm.Ages = db.Ages.ToList();

        //    return View(bnm);
        //}
    }
}