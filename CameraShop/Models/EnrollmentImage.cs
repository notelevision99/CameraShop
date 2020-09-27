using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CameraShop.Models
{
    public class EnrollmentImage
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int? file_id { get; set; }
        public int? ProductID { get; set; }

        public virtual Product Product { get; set; }
        public virtual FileImg FileImg { get; set; }
    }
}