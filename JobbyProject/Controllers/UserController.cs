using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using JobbyProject.DAL;
using JobbyProject.Models;
using JobbyProject.ViewModel;

namespace JobbyProject.Controllers
{
    public class UserController : Controller

    {

        private readonly JobbyProjectContext db = new JobbyProjectContext();

public static User current_user;
public static int user_id;

public string Fullname { get; private set; }

         //GET: User
        public ActionResult Register()
{
    return View();
}



[HttpPost]
public ActionResult Register(string FullName, string Email, string Password)
{

    User user = new User();
    user.Fullname = FullName;
    user.Password = Crypto.HashPassword(Password);
    user.Email = Email;
    current_user = user;

    db.Users.Add(user);
    db.SaveChanges();


    Session["user2"] = user;
    Session["loguser"] = true;

    return RedirectToAction("Index", "Home");

}

public ActionResult Login()
{
    return View();
}

[HttpPost]
public ActionResult Login(User user)
{
    if (db.Users.Count(u => u.Email == user.Email) == 1)
    {

        if (Crypto.VerifyHashedPassword(db.Users.First(u => u.Email == user.Email).Password, user.Password))
        {
            current_user = db.Users.First(u => u.Email == user.Email);
            Session["userLogged"] = true;
            Session["user"] = db.Users.First(u => u.Email == user.Email);

            return RedirectToAction("Index", "Home");

        }
        else
        {
            ModelState.AddModelError("Loginerror", "Username  or  password is wrong");
        }

    }
    else
    {
        ModelState.AddModelError("Loginerror", "Username  or  password is wrong");

    }

    return View(user);

}
public ActionResult Logout()
{
    Session.Clear();
    return RedirectToAction("Index", "Home");
}

        public ActionResult Users()
        {
            ClassVM vm = new ClassVM();
            vm.users = db.Users.ToList();
            return View(vm);
        }

    }
}