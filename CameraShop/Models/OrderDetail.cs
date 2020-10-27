using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraShop.Models
{
    public class OrderDetail
    {
        
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }

        public int OrderID { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}