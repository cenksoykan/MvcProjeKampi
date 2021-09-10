using System.Web;
using System.Web.Optimization;

namespace MvcProjeKampi
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/sweetalert2-11.1.4.min.js",
                      "~/Scripts/summernote-lite-0.8.18.min.js",
                      "~/Scripts/summernote-tr-TR-0.8.18.js",
                      "~/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/gallery").Include(
                      "~/Scripts/imagesloaded-4.1.4.pkgd.min.js",
                      "~/Scripts/masonry-4.2.2.pkgd.min.js",
                      "~/Scripts/fancybox-4.0.0.umd.min.js",
                      "~/Scripts/gallery.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-icons-1.5.0.css",
                      "~/Content/summernote-lite-0.8.18.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/gallery").Include(
                      "~/Content/fancybox-4.0.0.min.css",
                      "~/Content/gallery.css"));
        }
    }
}
