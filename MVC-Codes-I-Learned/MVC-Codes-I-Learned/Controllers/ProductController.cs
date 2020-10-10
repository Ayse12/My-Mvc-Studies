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

        //Sayfa yüklendiğinde sadece tasarımı geriye döndürür.
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> value = (from i in db.Categories.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.CategoryName,
                                              Value = i.CategoryID.ToString()
                                          }).ToList();
            ViewBag.vlu = value;
            return View();
        }

        //Sayfada işlem yapılmadığı sürece aşağıdaki veri tabanına ekleme işlemini gerçekleştirmez.
        [HttpPost]
        public ActionResult NewProduct(Products p1)
        {
            var ctgry = db.Categories.Where(m => m.CategoryID == p1.CategoryID).FirstOrDefault();
            p1.Categories = ctgry;
            db.Products.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Product");
        }
        public ActionResult Delete(int id)
        {
            var prdct = db.Products.Find(id);
            db.Products.Remove(prdct);
            db.SaveChanges();
            return RedirectToAction("Product");
        }
    }
}