using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobbyProject.Models;
using JobbyProject.ViewModel;
using JobbyProject.DAL;

namespace JobbyProject.Controllers
{
    public class ClassesController : Controller
    {
        private readonly JobbyProjectContext db =new JobbyProjectContext();
       
        // GET: Classes
        public ActionResult Index()
        {
            ClassVM bnm = new ClassVM();
           

            bnm.classes = db.Classes.ToList();
            bnm.Ages = db.Ages.ToList();

            return View(bnm);
        }



        public ActionResult SingleClass( )
        {

            ClassSingle bnm = new ClassSingle();
          
          
            bnm.Ages = db.Ages.ToList();
            return View(bnm);

           
        }
    }
}