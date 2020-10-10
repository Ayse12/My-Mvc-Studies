using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Codes_I_Learned.Models.Entity;

namespace MVC_Codes_I_Learned.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index()
        {
            var values = db.Categories.ToList();
            return View(values);
        }

        //Sayfa yüklendiğinde sadece tasarımı geriye döndürür.
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        //Sayfada işlem yapılmadığı sürece aşağıdaki veri tabanına ekleme işlemini gerçekleştirmez.
        [HttpPost]
        public ActionResult NewCategory(Categories p1)
        {
            db.Categories.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var ctgry = db.Categories.Find(id);
            db.Categories.Remove(ctgry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var ctgry = db.Categories.Find(id);
            return View("GetCategory", ctgry);
        }
    }
}