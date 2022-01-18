using CameraShop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CameraShop.ViewModels
{
    public class ProductListViewModel
    {
        public IPagedList<Product> Products { get; set; }
        public IEnumerable<Category> MainCategories { get; set; }
        public IEnumerable<Category> AllCategories { get; set; }
    }
}