using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;


namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string user)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {                                  
                    var dev = db.products.AsQueryable();                    
                    dev = dev.Where(u => u.Username == user);
                    if(dev.Count() > 0)
                    {
                        return PartialView(dev.ToList());
                    }                

                }

            }
            return RedirectToAction("Prof", "Account", new { str = "No Products Found..." });
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product prod)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.products.Add(prod);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = prod.Name +  " successfully Added!";

            }

            return View();
        }
    }
}