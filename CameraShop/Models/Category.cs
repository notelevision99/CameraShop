using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CameraShop.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Display(Name ="Loại sản phẩm")]
        [Required]
        public string  CategoryName { get; set; }

        public virtual ICollection<Product> Products{ get; set; }
    }
}