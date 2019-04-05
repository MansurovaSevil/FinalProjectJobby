using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobbyProject.Models;
using JobbyProject.DAL;
using JobbyProject.ViewModel;

namespace JobbyProject.Areas.Admin.Controllers
{
    [Authorizem]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
         
            return View();
            
        }
    }
}