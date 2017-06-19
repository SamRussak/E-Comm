using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Models;
namespace ECommerce.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult Index(UserAccount user)
        {
            if(ModelState.IsValid)
            {               
                    using (OurDbContext db = new OurDbContext())
                    {
                        var dev = db.products.AsQueryable();
                        dev = dev.Where(p => p.buyer == user);
                        if (dev.Count() > 0)
                        {
                            return View(dev.ToList());
                        }

                    }               
            }
            return View();
        }
    }
}