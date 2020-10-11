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

        //Sayfa yüklendiğinde sadece tasarımı geriye döndürür.
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        //Sayfada işlem yapılmadığı sürece aşağıdaki veri tabanına ekleme işlemini gerçekleştirmez.
        [HttpPost]
        public ActionResult NewCustomer(Customers p1)
        {
            db.Customers.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(string id)
        {
            var cstmr = db.Customers.Find(id);
            db.Customers.Remove(cstmr);
            db.SaveChanges();
            return RedirectToAction("Customer");
        }

        public ActionResult GetCustomer(string id)
        {
            var cstmr = db.Customers.Find(id);
            return View("GetCustomer", cstmr);
        }
        public ActionResult Update(Customers c1)
        {
            var cstmr = db.Customers.Find(c1.CustomerID);
            cstmr.ContactName = c1.ContactName;
            cstmr.ContactTitle = c1.ContactTitle;
            cstmr.City = c1.City;
            db.SaveChanges();
            return RedirectToAction("Customer");
        }
    }
}