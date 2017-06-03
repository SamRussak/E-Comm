using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Join the E-Comm Family!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Reach out if there are any issues!";

            return View();
        }


    }
}