using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CameraShop.Models
{
    public class ProductSpecification
    {
        [Key]
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [Display(Name ="Thông số thứ nhất")]
        public string FirstTitle { get; set; }
        [Display(Name ="Thông số thứ hai")]
        public string SecondTitle { get; set; }

        public virtual Product Product { get; set; }
    }
}