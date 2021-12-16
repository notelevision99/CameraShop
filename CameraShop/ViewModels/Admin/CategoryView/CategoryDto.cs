using CameraShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CameraShop.ViewModels.Admin.CategoryView
{
    public class CategoryDto
    {
        public List<Category> Categories { get; set; }
        public List<string> SubCategories { get; set; }
    }
}