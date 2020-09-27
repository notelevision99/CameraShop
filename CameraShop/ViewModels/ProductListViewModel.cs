using CameraShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CameraShop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}