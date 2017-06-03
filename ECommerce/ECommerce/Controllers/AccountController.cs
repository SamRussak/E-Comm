using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register( UserAccount user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (OurDbContext db = new OurDbContext())
                    {
                        if (db.userAccount.Any(u => u.Username == user.Username))
                        {
                            ModelState.AddModelError("", "Username already exists");
                            return View();
                        }
                        db.userAccount.Add(user);
                        db.SaveChanges();
                    }
                    ModelState.Clear();                    
                }

                return View();
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Username already exists");
                return View();
            }
           
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            try
            {
                using (OurDbContext db = new OurDbContext())
                {
                    var usr = db.userAccount.Single(u => u.Username == user.Username && u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["UserID"] = usr.UserID.ToString();
                        Session["Username"] = usr.Username.ToString();
                        return RedirectToAction("Profile");
                    }
                }
                return View();
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Username or Password is wrong!");
                return View();
            }
        }

        public ActionResult Profile()
        {
            if(Session["UserID"] != null)
            {
                return View();
            }            
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Prof (String str)
        {
            if (Session["UserID"] != null)
            {
                ViewBag.Message = str;
                return View("Profile");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}