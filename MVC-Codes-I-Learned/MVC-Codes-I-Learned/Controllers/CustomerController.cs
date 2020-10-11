using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Codes_I_Learned.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC_Codes_I_Learned.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Customer(string p /*int page = 1*/)
        {
            var values = from d in db.Customers select d;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(m => m.ContactName.Contains(p));
            }
            return View(values.ToList());
            //var values = db.Customers.ToList();
            //var values = db.Customers.ToList().ToPagedList(page, 10);
            // return View(values);

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
            if (!ModelState.IsValid)
            {
                return View("NewCustomer");
            }
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