using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobbyProject.DAL;
using JobbyProject.Models;
using JobbyProject.ViewModel;

namespace JobbyProject.Controllers
{
    public class AjaxController : Controller
    {
        private JobbyProjectContext db = new JobbyProjectContext();

        // GET: Ajax
        [HttpPost]
        public ActionResult CommentList(string description, int? postId)
        {
            User user = Session["user"] as User;

            if (user == null)
            {
                return Json(0);
            }
           
                Comment comments = new Comment();

                comments.BlogID = postId.Value;
                comments.Description = description;
                comments.UserID = user.ID;
                comments.Date = DateTime.Now;
                db.Comments.Add(comments);
                db.SaveChanges();

                return PartialView("_PartialPage1", comments);
           
        }
    }
}