using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CameraShop.Models
{
    public class FileImg
    {
        [Key]
        
        public int  file_id { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public string file_base6 { get; set; }     
        public virtual ICollection<Product> Products { get; set; }
    }
}