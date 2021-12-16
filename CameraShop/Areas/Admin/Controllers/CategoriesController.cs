using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CameraShop.DAL;
using CameraShop.Models;
using CameraShop.ViewModels.Admin.CategoryView;

namespace CameraShop.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create(int? id)
        {
            if(id == null)
            {
                return View();
            }
            Category categories = db.Categories.FirstOrDefault(p => p.CategoryID == id);
            categories.CategoryParentID = id;
            return View(categories);
            //cateogoriesDto.Categories.Add(categories);

            //var isHasSubCates = db.Categories.FirstOrDefault(p => p.CategoryParentID == categories.CategoryID);
            //if (isHasSubCates != null)
            //{
            //    var subCates = db.Categories.Where(p => p.CategoryParentID == categories.CategoryID).ToList();
            //    foreach (var item in subCates)
            //    {
            //        cateogoriesDto.Categories.Add(item);
            //    }
            //}

        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,CategoryParentID")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryID == 0)
                {
                    db.Categories.Add(category);
                }
                else
                {
                    category.CategoryParentID = category.CategoryID;
                }
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            CategoryDto cateogoriesDto = new CategoryDto();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category categories = db.Categories.FirstOrDefault(p => p.CategoryID == id);
            //cateogoriesDto.Categories.Add(categories);

            //var isHasSubCates = db.Categories.FirstOrDefault(p => p.CategoryParentID == categories.CategoryID);
            //if(isHasSubCates != null)
            //{
            //    var subCates = db.Categories.Where(p => p.CategoryParentID == categories.CategoryID).ToList();
            //    foreach(var item in subCates)
            //    {
            //        cateogoriesDto.Categories.Add(item);
            //    }
            //}
            return View(categories);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,CategoryParentID")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
