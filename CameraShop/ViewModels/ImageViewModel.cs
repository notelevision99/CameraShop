using CameraShop.HelperCode;
using CameraShop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CameraShop.ViewModels
{
    public class ImageViewModel
    {
        [Required]
        [Display(Name = "Upload File")]
        public HttpPostedFileBase FileAttach { get; set; }

        /// <summary>  
        /// Gets or sets Image file list.  
        /// </summary>  
        public List<ImgObj> ImgLst { get; set; }
    }
}