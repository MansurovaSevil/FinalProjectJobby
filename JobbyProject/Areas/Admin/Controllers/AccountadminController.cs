using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobbyProject.Models;
using JobbyProject.DAL;
using System.Web.Helpers;
using JobbyProject.ViewModel;

namespace JobbyProject.Areas.Admin.Controllers
{
 
    public class AccountadminController : Controller
    {
        
        private JobbyProjectContext db = new JobbyProjectContext();

        public static Adminka current_admin;
        public static int admin_id;
        // GET: Admin/Accountadmin
        public ActionResult LogIndex()
        {
         
            return View();
        }
       

        [HttpPost]
        public ActionResult LogIndex(Adminka adminka)
        {
            if (db.Adminkas.Count(u => u.Email == adminka.Email)==1)
            {
                if (Crypto.VerifyHashedPassword(db.Adminkas.First(u => u.Email == adminka.Email).Password, adminka.Password))
                {
                    current_admin = db.Adminkas.First(u => u.Email == adminka.Email);
                    Session["adminLogged"] = true;
                    Session["Admin"] = db.Adminkas.First(u => u.Email == adminka.Email);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("Loginerror", "Email or password is wrong");
                }
            }
            else
            {
                ModelState.AddModelError("Loginerror", "Email or password is wrong");
            }



                return View(adminka);
        }
           
    }
}