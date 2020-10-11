using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Codes_I_Learned.Models.Entity;

namespace MVC_Codes_I_Learned.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult Sales()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewSales()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSales(Orders or)
        {
            db.Orders.Add(or);
            db.SaveChanges();
            return RedirectToAction("Sales");
        }
    }
}