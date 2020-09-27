using CameraShop.HelperCode;
using CameraShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CameraShop.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<EnrollmentImage> EnrollmentImages { get; set; }
        public List<ImgObj> ImgList { get; set; }
    }
}