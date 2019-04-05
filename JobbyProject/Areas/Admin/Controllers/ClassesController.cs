using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobbyProject.DAL;
using JobbyProject.Extino;
using JobbyProject.Models;
using JobbyProject.ViewModel;

namespace JobbyProject.Areas.Admin.Controllers
{
    [Authorizem]
    public class ClassesController : Controller
    {
        private JobbyProjectContext db = new JobbyProjectContext();

        // GET: Admin/Classes
        public ActionResult Index()
        {
            var jobbycontext = db.Classes.Include(m => m.category).Include(m => m.teacher);
            return View(jobbycontext.ToList());
        }

        // GET: Admin/Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class klas = db.Classes.Find(id);
            if (klas == null)
            {
                return HttpNotFound();
            }
            return View(klas);
        }

        // GET: Admin/Classes/Create
        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Fullname");
            ViewBag.Teachers = db.Teachers.ToList();
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Categories = db.Categories.ToList();



            return View();
        }

        // POST: Admin/Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Image,Price,Description,SizeSeat,OpenHours,CloseHours,StartDate,AgeID,CategoryID,TeacherID")] Class klas, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Extension.CheckImg(Image, Extension.MAxfileSize))
                {


                    try
                    {
                        klas.Image = Extension.SaveImg(Image, "~/Public/images");
                    }
                    catch
                    {

                        return View(klas);
                    }

                }
                else
                {
                    return View(klas);
                }


                db.Classes.Add(klas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(klas);
        
        }

        // GET: Admin/Classes/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Fullname");
            ViewBag.Teachers = db.Teachers.ToList();
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Categories = db.Categories.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class klas = db.Classes.Find(id);
            if (klas == null)
            {
                return HttpNotFound();
            }
            return View(klas);

        }

      

        // POST: Admin/Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Image,Price,Description,SizeSeat,OpenHours,CloseHours,StartDate,AgeID,CategoryID,TeacherID")] Class klas, HttpPostedFileBase Image, string nazvaniye)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {

                    if (Extension.CheckImg(Image, Extension.MAxfileSize))
                    {
                        try
                        {
                            klas.Image = Extension.SaveImg(Image, "~/Public/images");

                        }
                        catch
                        {

                            return View(klas);
                        }

                        Extension.Deletimg("~/Public/images", nazvaniye);

                    }
                    else
                    {
                        return View(klas);
                    }

                }
                else
                {
                    klas.Image = nazvaniye;
                }
                db.Entry(klas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klas);
        }

        // GET: Admin/Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class klas = db.Classes.Find(id);
            if (klas == null)
            {
                return HttpNotFound();
            }
            return View(klas);
        }

        // POST: Admin/Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class klas = db.Classes.Find(id);
            db.Classes.Remove(klas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
