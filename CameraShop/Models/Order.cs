using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CameraShop.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public string  OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }

        
        public string CustomerName { get; set; }

        
        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }
       
        public string CustomerAddress { get; set; }

        
        public string OrderNote { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}