using System.Web;
using System.Web.Optimization;

namespace CameraShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //admin template jquery--------------------------
            bundles.Add(new ScriptBundle("~/bundles/adminjquery").Include(
                           "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.min.js"));
            //-------------------------------------

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                      "~/Content/Admin/css/styles.css"

                      ));
            //client bundle
            bundles.Add(new StyleBundle("~/Content/clientcss").Include(
                     "~/Content/Client/css/font-awesome.min.css",
                     "~/Content/Client/css/animate.css",
                     "~/Content/Client/css/themify-icons.css",
                     "~/Content/Client/css/stroke-gap.css",
                     "~/Content/Client/css/material-design-iconic-font.min.css",
                     "~/Content/Client/css/nice-select.css",
                     "~/Content/Client/css/jquery.fancybox.css",
                     "~/Content/Client/css/jquery-ui.min.css",
                     "~/Content/Client/css/meanmenu.min.css",
                     "~/Content/Client/css/owl.carousel.min.css",
                     "~/Content/Client/css/bootstrap.min.css",
                     "~/Content/Client/css/default.css",
                     "~/Content/Client/css/slick.css",
                     "~/Content/Client/css/responsive.css"
                    
                     ));
            bundles.Add(new StyleBundle("~/Content/clientStyleCss").Include(
                     "~/Content/Client/style.css"));
            //Scripts client bundles
            bundles.Add(new ScriptBundle("~/bundles/clientjquery").Include(
                       
                        "~/Scripts/Clients/jquery.meanmenu.min.js",
                        "~/Scripts/Clients/jquery.scrollUp.js",
                        "~/Scripts/Clients/jquery.fancybox.min.js",
                        "~/Scripts/Clients/jquery.countdown.min.js",
                        "~/Scripts/Clients/jquery.nice-select.min.js",
                        "~/Scripts/Clients/jquery-ui.min.js"   
                        ));

            bundles.Add(new ScriptBundle("~/bundles/clientjs").Include(
                        "~/Scripts/Clients/owl.carousel.min.js",
                        "~/Scripts/Clients/slick.min.js",
                        "~/Scripts/Clients/popper.min.js",
                        "~/Scripts/Clients/bootstrap.min.js",
                        "~/Scripts/Clients/plugins.js",
                        "~/Scripts/Clients/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/clientModernizr").Include(
                        "~/Scripts/Clients/vendor/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/adminjs").Include(
                     //"~/Scripts/Admin/build-assets.js",
                     //"~/Scripts/Admin/build-pug.js",
                     //"~/Scripts/Admin/build-scripts.js",
                     //"~/Scripts/Admin/build-scss.js",
                     //"~/Scripts/Admin/clean.js",
                     //// "~/Scripts/Admin/render-assets.js"
                     ////"~/Scripts/Admin/render-pug.js",
                     ////"~/Scripts/Admin/render-scripts.js",
                     ////"~/Scripts/Admin/render-scss.js",
                     //"~/Scripts/Admin/sb-watch.js",
                     //"~/Scripts/Admin/start-debug.js",
                     //"~/Scripts/Admin/start.js",
                     "~/Scripts/Admin/scripts.js",
                      "~/Scripts/Admin/bootstrap.min.js"
                     ));
        }
    }
}
