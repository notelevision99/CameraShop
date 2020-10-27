using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CameraShop.Models
{
    public class Product
    {
        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Display(Name ="Mã sản phẩm")]
        [Required]
        public string ProductSKU { get; set; }
        [Display(Name ="Tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Giá gốc")]
        [DisplayFormat(DataFormatString = "{0:#,0} đ", ApplyFormatInEditMode = false)]
        public decimal OriPrice { get; set; }

        [Display(Name ="Tên sản phẩm(URL)")]
        [Required]
        public string Alias { get; set; }

        [Display(Name = "Giá đã giảm")]
        [DisplayFormat(DataFormatString = "{0:#,0} đ", ApplyFormatInEditMode = false)]
        public decimal DiscountedPrice { get; set; }

        [AllowHtml]
        public string ProductSpecification { get; set; }

        [AllowHtml]
        public string ProductIntro { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

       

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails  { get; set; }
        public virtual ICollection<FileImg> FileImgs { get; set; }


    }
}