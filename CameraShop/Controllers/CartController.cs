using CameraShop.DAL;
using CameraShop.HelperCode;
using CameraShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CameraShop.Controllers
{
    public class CartController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cart()
        {
            var cart = (List<Item>)Session["cart"];
            return View(cart);
        }

        public ActionResult CheckOut()
        {
            return View("CheckOut");
        }

        
        public ActionResult ProcessOrder(FormCollection frc)
        {
            List<Item> lstCart = (List<Item>)Session["cart"];
            Order order = new Order()
            {
                CustomerName = frc["cusName"],
                CustomerAddress = frc["cusAddress"],
                CustomerEmail = frc["cusEmail"],
                CustomerPhone = frc["cusPhone"],
                OrderDate = DateTime.Now,
                Status = true,
                
            };
            db.Orders.Add(order);
            db.SaveChanges();
            foreach (Item item in lstCart)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderID = order.OrderID,
                    ProductID = item.Product.ProductID,
                    Quantity = item.Quantity

                };
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }
            Session.Remove("cart");

            return View("OrderSuccess");
        }
    }
}