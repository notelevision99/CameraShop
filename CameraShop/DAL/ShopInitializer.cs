using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CameraShop.Models;

namespace CameraShop.DAL
{
    public class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            var products = new List<Product>
            {
                new Product{ProductID = 1,ProductName = "Camera Vision", OriPrice = 200000,DiscountedPrice = 100000, CategoryID = 1},
                new Product{ProductID = 2,ProductName = "Camera Sess", OriPrice = 250000,DiscountedPrice = 150000,CategoryID = 2},
                new Product{ProductID = 3,ProductName = "Camera Saxz", OriPrice = 200000,DiscountedPrice = 100000,CategoryID = 2},
                new Product{ProductID = 4,ProductName = "Camera HGA", OriPrice = 200000,DiscountedPrice = 100000,CategoryID = 1},
                new Product{ProductID = 5,ProductName = "Camera PAG", OriPrice = 200000,DiscountedPrice = 100000,CategoryID = 2},
                new Product{ProductID = 6,ProductName = "Camera HM", OriPrice = 200000,DiscountedPrice = 100000,CategoryID = 1},

            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
            var categories = new List<Category>
            {
                new Category{CategoryID = 1,CategoryName = "Cam Vision"},
                new Category {CategoryID = 2,CategoryName= "Cam hong ngoai"}

            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();
        }
    }
}