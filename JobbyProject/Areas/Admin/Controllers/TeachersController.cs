using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobbyProject.DAL;
using JobbyProject.Models;
using JobbyProject.Extino;
using JobbyProject.ViewModel;

namespace JobbyProject.Areas.Admin.Controllers
{
    [Authorizem]
    public class TeachersController : Controller
    {
        private JobbyProjectContext db = new JobbyProjectContext();

        // GET: Admin/Teachers
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }

        // GET: Admin/Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Admin/Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Fullname,Image,Tittle,Description,Special,Experience,Phone,Email,SliderDesc,")] Teacher teacher,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Extension.CheckImg(Image, Extension.MAxfileSize))
                {


                    try
                    {
                        teacher.Image = Extension.SaveImg(Image, "~/Public/images");
                    }
                    catch 
                    {

                        return View(teacher);
                    }

                }
                else
                {
                    return View(teacher);
                }

                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Admin/Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Admin/Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Fullname,Image,Tittle,Description,Special,Experience,Phone,Email,SliderDesc")] Teacher teacher,HttpPostedFileBase Image,string fileadi)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {

                    if (Extension.CheckImg(Image, Extension.MAxfileSize))
                    {
                        try
                        {
                            teacher.Image = Extension.SaveImg(Image, "~/Public/images");

                        }
                        catch
                        {

                            return View(teacher);
                        }

                        Extension.Deletimg("~/Public/images", fileadi);

                    }
                    else
                    {
                        return View(teacher);
                    }

                }
                else
                {
                    teacher.Image = fileadi;
                }

                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Admin/Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Admin/Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Teacher teacher = db.Teachers.Find(id);
            Extension.Deletimg("~/Public/images", teacher.Image);
            db.Teachers.Remove(teacher);
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
