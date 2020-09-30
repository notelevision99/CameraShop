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
using CameraShop.ViewModels;

namespace CameraShop.Controllers
{
    public class CategoryController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Category
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<Category> categories = db.Categories.ToList();

            if (Category == null)
            {
                products = db.Products
                    .Include(i => i.FileImgs)
                    .ToList();
               
            }
            else
            {
                products = db.Products.Where(p => p.Category.CategoryName == Category).ToList();
                ViewBag.CountProd = products.Count();
                ViewBag.Category = Category;
            }
            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.Categories = categories;
            return View(model);
        }

        // GET: Category/Details/5
        public ActionResult Details(int? categoryID)
        {
            if (categoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(categoryID);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
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
