using CameraShop.DAL;
using CameraShop.HelperCode;
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
    }
}