using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CameraShop.DAL;
using CameraShop.HelperCode;
using CameraShop.Models;
using CameraShop.ViewModels;
using PagedList;
namespace CameraShop.Controllers
{
    public class HomeController : Controller
    {
        
        private ShopContext db = new ShopContext();

        // GET: Home
        public ActionResult Index(string currentFilter,string searchString, int? page)
        {
            int pageSize = 9;
            int productPageNumber = (page ?? 1);
            var products = db.Products.Include(i => i.Category)
                .Include(p => p.FileImgs);      
            //Paging when search
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.SearchString = searchString;
                products = products.Where(s => s.ProductName.Contains(searchString)
                                       || s.Category.CategoryName.Contains(searchString));
                ViewBag.CountProducts = products.Count();
                return View("Search",products.OrderBy(p => p.ProductName).ToPagedList(productPageNumber,pageSize));
            }
          
            return View(products.ToList());
        }
        // GET: Home/Details/5
        public ActionResult Details(string alias)
        {
            RelateProductViewModel model = new RelateProductViewModel();
            if (alias == null)
            {
                return View("Error");
            }
            //Chi tiết 1 sản phẩm
            model.Product = db.Products.SingleOrDefault(p => p.Alias == alias);
            ViewBag.Category = model.Product.Category.CategoryName;
            //List sản phẩm liên quan
            model.Products = db.Products.Include(p => p.Category)
                .Include(p => p.FileImgs).OrderBy(p => p.ProductName);
            if (model.Product == null)
            {
                return View("Error");
            }
            return View(model);
        }



        [HttpPost]
        public ActionResult AddToCart(int productID, int quantity)
        {         
            if (Session["cart"] == null)
            {
                var cart = new List<Item>();
                var product = db.Products.Include(p => p.FileImgs)
                    .SingleOrDefault(x => x.ProductID == productID);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = quantity
                });
                Session["cart"] = cart;
                Session["cartCounter"] = cart.Count();              
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = db.Products.Include(p => p.FileImgs)
                    .Single(x => x.ProductID == productID);
                List<int> addedItems = new List<int>();

                foreach (var item in cart)
                {
                    addedItems.Add(item.Product.ProductID);
                   
                }
                //var product = db.Products.Find(productID);
                foreach (var item in cart.ToList())
                {
                    if (item.Product.ProductID == productID)
                    {
                        int preQty = item.Quantity;
                        cart.Remove(item);
                        cart.Add(new Item()
                        {
                            Product = product,
                            Quantity = preQty + quantity
                        });
                        Session["cart"] = cart;
                    }
                    else
                    {
                        if (addedItems.Contains(productID))
                        {
                            
                        }
                        else
                        {
                            cart.Add(new Item()
                            {
                                Product = product,
                                Quantity = quantity
                            });
                            Session["cartCounter"] = cart.Count();
                            break;
                        }
                        Session["cart"] = cart;
                                         
                    }                    
                }
                
            }

            return Json(new { success = true , Counter = Session["cartCounter"] }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");

        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            var categories = db.Categories.ToList();
            ViewBag.Categories = categories;
            return PartialView("Menu",categories);
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
