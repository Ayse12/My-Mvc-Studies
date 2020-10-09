using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Codes_I_Learned.Models.Entity;

namespace MVC_Codes_I_Learned.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Customer()
        {
            var values = db.Customers.ToList();
            return View(values);
        }
    }
}