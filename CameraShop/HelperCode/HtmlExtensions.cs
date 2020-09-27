using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CameraShop.HelperCode
{
    public static class HtmlExtensions
    {
        public static byte[] ToByteArray(this string str)
        {
            return System.Text.Encoding.ASCII.GetBytes(str);
        }
        public static MvcHtmlString Image(this HtmlHelper html, string imageBase6)
        {
            byte[] imageBytes = Convert.FromBase64String(imageBase6);
            
            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(imageBytes));
           
            return new MvcHtmlString("<img src='" + img + "' width = '"+"50"+ "' height = '" + "50" + "' />");
        }

        public static MvcHtmlString ImageDetail(this HtmlHelper html, string imageBase6)
        {
            byte[] imageBytes = Convert.FromBase64String(imageBase6);

            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(imageBytes));

            return new MvcHtmlString("<img src='" + img + "' width = '" + "100" + "' height = '" + "100" + "' />");
        }

        public static MvcHtmlString ImageSlick(this HtmlHelper html, string imageBase6)
        {
            byte[] imageBytes = Convert.FromBase64String(imageBase6);

            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(imageBytes));

            return new MvcHtmlString("<img class = '" + "primary-img" + "' src='" + img + "' /*width = '" + "270px" + "' height = '" + "270px" + "'*/  />");
        }
        public static MvcHtmlString LargeImageDetails(this HtmlHelper html, string imageBase6)
        {
            byte[] imageBytes = Convert.FromBase64String(imageBase6);

            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(imageBytes));

            return new MvcHtmlString("<a data-fancybox= '" + "images" + "' href = '" + img + "'  > <img src = '" + img +"'  alt = '" + "product-view" + "' > </a>" );
        }

        public static MvcHtmlString ThumbnailImages(this HtmlHelper html, string imageBase6)
        {
            byte[] imageBytes = Convert.FromBase64String(imageBase6);

            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(imageBytes));

            return new MvcHtmlString("<a class = '" + "active" + "' data-toggle = '" + "tab" + "' href = '" + "#thumb1" + "'  > <img src = '" + img + "' alt = '" + "product-thumbnail" + "'/> </a>");
        }


        public static MvcHtmlString ThumbnailImagesCount2(this HtmlHelper html, string imageBase6)
        {
            byte[] imageBytes = Convert.FromBase64String(imageBase6);

            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(imageBytes));

            return new MvcHtmlString("<img src = '" + img + "' alt = '" + "product-thumbnail" + "' >");
        }
    }
}