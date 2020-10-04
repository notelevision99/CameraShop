﻿namespace CameraShop.Migrations
{
    using CameraShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CameraShop.DAL.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(CameraShop.DAL.ShopContext context)
        {
            //var categories = new List<Category>
            //{
            //    new Category {CategoryID = 1, CategoryName = "Cam hong ngoai"},
            //    new Category {CategoryID = 2, CategoryName = "Cam tu dong"}
            //};
            //categories.ForEach(s => context.Categories.AddOrUpdate(p => p.CategoryName,s))  ;
            //context.SaveChanges();
            //var products = new List<Product>
            //{
            //    new Product {ProductID = 1, ProductName = "Camera b022", OriPrice = 100000,DiscountedPrice = 50000,CategoryID = 1},
            //    new Product {ProductID = 2, ProductName = "Camera b322", OriPrice = 500000,DiscountedPrice = 250000,CategoryID = 2},
            //    new Product {ProductID = 3, ProductName = "Camera b1322", OriPrice = 1000000,DiscountedPrice = 500000,CategoryID = 1}
            //};
            //products.ForEach(s => context.Products.AddOrUpdate(p => p.ProductName,s));
            //context.SaveChanges();


            //var fileimgs = new List<FileImg>
            //{
            //    new FileImg
            //    {
            //        file_name = "hinh hd.jpg", 
            //        file_ext="image/jpeg", 
            //        file_base6 = "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"
            //    }
            //};
            //fileimgs.ForEach(s => context.FileImgs.AddOrUpdate(p => p.file_name, s));
            //context.SaveChanges();

           

            
            
        }
    }
}
