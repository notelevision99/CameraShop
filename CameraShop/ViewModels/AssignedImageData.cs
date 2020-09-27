using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CameraShop.ViewModels
{
    public class AssignedImageData
    {
        public int file_id { get; set; }
        public string file_base6 { get; set; }
        public string file_name { get; set; }
        public bool Assigned { get; set; }
    }
}