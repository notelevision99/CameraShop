using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CameraShop.HelperCode
{
    public class ImgObj
    {
        public int FileId { get; set; }

        /// <summary>  
        /// Gets or sets Image name.  
        /// </summary>  
        public string FileName { get; set; }

        /// <summary>  
        /// Gets or sets Image extension.  
        /// </summary>  
        public string FileContentType { get; set; }
    }
}