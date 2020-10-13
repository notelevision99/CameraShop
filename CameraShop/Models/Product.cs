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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        [Display(Name ="Tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Giá gốc")]
        [DisplayFormat(DataFormatString = "{0:#,0} đ", ApplyFormatInEditMode = false)]
        public decimal OriPrice { get; set; }

        [Display(Name = "Giá đã giảm")]
        [DisplayFormat(DataFormatString = "{0:#,0} đ", ApplyFormatInEditMode = false)]
        public decimal DiscountedPrice { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [AllowHtml]
        public string ProductSpecification { get; set; }


        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails  { get; set; }
        public virtual ICollection<FileImg> FileImgs { get; set; }


    }
}