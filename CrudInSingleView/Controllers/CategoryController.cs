using CrudInSingleView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudInSingleView.Controllers
{
    public class CategoryController : Controller
    {
        ClassFourEntities db = new ClassFourEntities();
        // GET: Category
        public ActionResult Create()
        {
            var categoryData = new CategoryViewModel()
            {
                Categories = db.Categories.ToList()
            };
            return View(categoryData);
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            if(model.Category.CategoryId == 0)
            {
                db.Categories.Add(model.Category);
                db.SaveChanges();
            }
            else
            {
                var find = db.Categories.FirstOrDefault(x=>x.CategoryId == model.Category.CategoryId);
                find.Name = model.Category.Name;
                find.Description = model.Category.Description;
                //db.Entry(model.Category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            
            return RedirectToAction("Create");
        }
        public ActionResult Edit(int id)
        {
            var categoryData = new CategoryViewModel()
            {
                Categories = db.Categories.ToList(),
                Category = db.Categories.FirstOrDefault(x=>x.CategoryId == id)
            };
            return View("Create", categoryData);
        }
        public ActionResult Delete(int id)
        {
            var find = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            db.Categories.Remove(find);
            db.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}