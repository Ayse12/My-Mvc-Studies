using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Codes_I_Learned.Models.Entity;

namespace MVC_Codes_I_Learned.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Product()
        {
            var values = db.Products.ToList();
            return View(values);
        }
    }
}