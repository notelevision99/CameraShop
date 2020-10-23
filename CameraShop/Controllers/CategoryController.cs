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
using PagedList;

namespace CameraShop.Controllers
{
    public class CategoryController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Category
        //public ActionResult Index(string Category = null)
        //{          
        //    List<Product> products;
        //    List<Category> categories = db.Categories.ToList();

        //    if (Category == null)
        //    {
        //        products = db.Products
        //            .Include(i => i.FileImgs)
        //            .ToList();             
        //    }
        //    else
        //    {                
        //        products = db.Products.Where(p => p.Category.CategoryName == Category).ToList();
        //        ViewBag.CountProd = products.Count();
        //        ViewBag.Category = Category;          
        //    }
        //    ViewBag.CurrentFilter = Category;
        //    ProductListViewModel model = new ProductListViewModel();
        //    model.Products = products;
        //    model.Categories = categories;


        //    return View(model);
        //}

        //test IPAGELIST Category
        public ActionResult Index(string sortOrder,int? productPage, string Category = null )
        {
            int ProductPageNumber = (productPage ?? 1);
            int pageSize = 9;
            ViewBag.PriceSortParm = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "price_asc";
         
            // IPagedList<Product> products;
            List<Category> categories = db.Categories.ToList();
            var viewmodel = new ProductListViewModel();
            if (Category == null)
            {

                if (sortOrder != null && sortOrder == "price_desc")
                {
                    viewmodel.Products = db.Products.OrderByDescending(p => p.DiscountedPrice)
                        .ToPagedList(ProductPageNumber, pageSize);
                }
                else if (sortOrder != null && sortOrder == "price_asc")
                {
                    viewmodel.Products = db.Products.OrderBy(p => p.DiscountedPrice)
                       .ToPagedList(ProductPageNumber, pageSize);
                }
                else
                {
                    viewmodel.Products = db.Products
                      .Include(i => i.FileImgs)
                      .OrderBy(p => p.ProductName)
                      .ToPagedList(ProductPageNumber, pageSize);
                }
            }
            else
            {
                viewmodel.Products = db.Products.Where(p => p.Category.CategoryName == Category).OrderBy(i => i.ProductName).ToPagedList(ProductPageNumber, pageSize);
                //ViewBag.CountProd = products.Count();

                //lọc != null
                if (sortOrder != null && sortOrder == "price_desc")
                {
                    viewmodel.Products = db.Products.Where(p => p.Category.CategoryName == Category).OrderByDescending(i => i.DiscountedPrice).ToPagedList(ProductPageNumber, pageSize);
                }
                else if (sortOrder != null && sortOrder == "price_asc")
                {
                    viewmodel.Products = db.Products.Where(p => p.Category.CategoryName == Category).OrderBy(i => i.DiscountedPrice).ToPagedList(ProductPageNumber, pageSize);
                }
                //lấy giá trị của category hiện tại truyền cho view
                ViewBag.Category = Category;

                ViewBag.CountProd = viewmodel.Products.Count();
            }

            ViewBag.Prod = viewmodel.Products;
            ViewBag.SortOrder = sortOrder;
            viewmodel.Categories = categories;
            return View(viewmodel);
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
