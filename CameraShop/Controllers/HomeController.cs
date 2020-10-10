﻿using System;
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

namespace CameraShop.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Home
        public ActionResult Index()
        {
            var products = db.Products.Include(i => i.Category)
                .Include(p => p.FileImgs);
             return View(products.ToList());
        }
        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }



        [HttpPost]
        public ActionResult AddToCart(int productID)
        {
             
            if (Session["cart"] == null)
            {
                var cart = new List<Item>();
                var product = db.Products.Include(p => p.FileImgs)
                    .SingleOrDefault(x => x.ProductID == productID);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
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
                            Quantity = preQty + 1
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
                                Quantity = 1
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
