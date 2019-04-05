using JobbyProject.DAL;
using JobbyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobbyProject.ViewModel;

namespace JobbyProject.Controllers
{
    public class SingleController : Controller
    {
        private JobbyProjectContext db = new JobbyProjectContext();
        // GET: Single
        public ActionResult Index (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index","Error");
            }
            BlogSingles bnm = new BlogSingles();
            bnm.blog = db.Blogs.Find(id);
            bnm.adminkas = db.Adminkas.ToList();
            bnm.galeryBlogs = db.GaleryBlogs.ToList();
            bnm.blogCategs = db.GetBlogCategs.ToList();
            bnm.LastBlog = db.Blogs.OrderByDescending(m => m.ID).Take(3).ToList();
            bnm.comajax = db.Comments.Where(m=>m.BlogID==id).ToList();
            bnm.users = db.Users.ToList();


            if (db.GaleryBlogs.Count() > 2 )
            {
                bnm.galery2Image = db.GaleryBlogs.Where(m=>m.BlogID==id).OrderBy(m=>m.ID).Skip(1).ToList();


            }
            else
            {
                bnm.galery2Image = db.GaleryBlogs.ToList();
            }
         

            return View(bnm);

        }



        // GET: Single
        //    public ActionResult AddComment(string description, int blockId)
        //    {
        //        var user = Session["user"] as User;


        //        int userId = user.ID;

        //        if (!String.IsNullOrEmpty(description) && blockId != 0)
        //        {
        //            Comment comments = new Models.Comment
        //            {
        //                Description = description,

        //                BlogID = blockId,
        //                UserID = userId,
        //                Date = DateTime.Now,
        //            };
        //            db.Comments.Add(comments);
        //            db.SaveChanges();
        //            return PartialView("_PartialPage1", comments);
        //        }

        //        return Json("fail");
        //    }
    }
}