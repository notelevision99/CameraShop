using CameraShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CameraShop.ViewModels
{
    public class RelateProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}