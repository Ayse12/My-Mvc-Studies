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
    public class CategoryController : Controller
    {
        // GET: Category

        NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index(int page=1)
        {
            //var values = db.Categories.ToList();
            var values = db.Categories.ToList().ToPagedList(page, 10);
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
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
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
        public ActionResult Update(Categories c1)
        {
            var ctgry = db.Categories.Find(c1.CategoryID);
            ctgry.CategoryName = c1.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
