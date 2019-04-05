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
using JobbyProject.ViewModel;
using JobbyProject.Extino;

namespace JobbyProject.Areas.Admin.Controllers
{
    public class GaleryBlogsController : Controller
    {
        private JobbyProjectContext db = new JobbyProjectContext();

        // GET: Admin/GaleryBlogs
        public ActionResult Index()
        {
            var galeryBlogs = db.GaleryBlogs.Include(g => g.blog);
            return View(galeryBlogs.ToList());
        }

        // GET: Admin/GaleryBlogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GaleryBlog galeryBlog = db.GaleryBlogs.Find(id);
            if (galeryBlog == null)
            {
                return HttpNotFound();
            }
            return View(galeryBlog);
        }

        // GET: Admin/GaleryBlogs/Create
        public ActionResult Create()
        {
            ViewBag.BlogID = new SelectList(db.Blogs, "ID", "Name");
            return View();
        }

        // POST: Admin/GaleryBlogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BlogID")] GaleryBlog galeryBlog, IEnumerable<HttpPostedFileBase> ImageBlog)
        {
            // Esli ne budet rabotat na verxu napisat IEnumerable///////////////////////////////

            if (ModelState.IsValid)
            {
                foreach (var item in ImageBlog)
                {
                    if (Extension.CheckImg(item, Extension.MAxfileSize))
                    {
                        try
                        {
                            galeryBlog.ImageBlog = Extension.SaveImg(item, "~/Public/images");

                        }
                        catch
                        {

                            ModelState.AddModelError("ImageBlog", "Img is not correct");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageBlog", "Img is not correct");
                    }



                    GaleryBlog gales = new GaleryBlog
                    {
                        ID = galeryBlog.ID,
                        ImageBlog = galeryBlog.ImageBlog,
                        BlogID = galeryBlog.BlogID
                    };
                    db.GaleryBlogs.Add(gales);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }


            ViewBag.BlogID = new SelectList(db.Blogs, "ID", "Name", galeryBlog.BlogID);
            return View(galeryBlog);

        }

        // GET: Admin/GaleryBlogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GaleryBlog galeryBlog = db.GaleryBlogs.Find(id);
            if (galeryBlog == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogID = new SelectList(db.Blogs, "ID", "Name", galeryBlog.BlogID);
            return View(galeryBlog);
        }

        // POST: Admin/GaleryBlogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BlogID")] GaleryBlog galeryBlog, IEnumerable<HttpPostedFileBase> ImageBlog, string file_adi)
        {
            if (ModelState.IsValid)
            {

                foreach (var item in ImageBlog)
                {
                    if (Extension.CheckImg(item, Extension.MAxfileSize))
                    {
                        try
                        {
                            galeryBlog.ImageBlog = Extension.SaveImg(item, "~/Public/images");

                        }
                        catch
                        {

                            ModelState.AddModelError("ImageBlog", "Img is not correct");
                        }

                        Extension.Deletimg("~/Public/images", file_adi);
                    }
                
                    //else
                    //{
                    //    ModelState.AddModelError("ImageBlog", "Img is not correct");
                    //}
                
                    else
                    {
                        galeryBlog.ImageBlog = file_adi;
                    }
                
                GaleryBlog gales = new GaleryBlog
                    {
                        ID = galeryBlog.ID,
                        ImageBlog = galeryBlog.ImageBlog,
                        BlogID = galeryBlog.BlogID
                    };
                    db.Entry(galeryBlog).State = EntityState.Modified;
                    db.GaleryBlogs.Add(gales);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
 
            }
            //ViewBag.BlogID = new SelectList(db.Blogs, "ID", "Name", galeryBlog.BlogID);
            return View(galeryBlog);
        }

        // GET: Admin/GaleryBlogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GaleryBlog galeryBlog = db.GaleryBlogs.Find(id);
            if (galeryBlog == null)
            {
                return HttpNotFound();
            }
            return View(galeryBlog);
        }

        // POST: Admin/GaleryBlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GaleryBlog galeryBlog = db.GaleryBlogs.Find(id);
            db.GaleryBlogs.Remove(galeryBlog);
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
