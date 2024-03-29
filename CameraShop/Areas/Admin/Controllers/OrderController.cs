﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CameraShop.DAL;
using CameraShop.Models;
using PagedList;

namespace CameraShop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Admin/Order
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 2;
            var orders = db.Orders.OrderByDescending(c => c.OrderDate);
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                currentFilter = searchString;
            }
            
            ViewBag.CurrentFilter = currentFilter;
            if(!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(c => c.CustomerName.Contains(searchString) || c.CustomerAddress.Contains(searchString) 
                                    || c.CustomerEmail.Contains(searchString)
                                    || c.CustomerPhone.Contains(searchString))
                                    .OrderBy(p => p.CustomerName);


                ViewBag.SearchString = searchString;
                return View(orders.ToPagedList(pageNumber, pageSize));
            }
               
            return View(orders.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

       

        // GET: Admin/Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderName,OrderDate,Status,CustomerName,CustomerPhone,CustomerEmail,CustomerAddress,OrderNote")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Admin/Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
