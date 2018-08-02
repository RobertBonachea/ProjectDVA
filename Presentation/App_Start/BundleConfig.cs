using System.Web;
using System.Web.Optimization;

namespace Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Site JS files
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-min.js",
                        "~/Scripts/jquery-migrate-1.0.0.js",
                        "~/Scripts/jquery.ui.js",
                        "~/Scripts/modernizr-2.8.3.js",
                        "~/Scripts/superfish.js",
                        "~/Scripts/jquery.maskedinput.js",
                        "~/Scripts/modalforms.js",
                        "~/Scripts/custom.js"));

            // JQuery validate
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Moment
            bundles.Add(new ScriptBundle("~/bundles/moment/js").Include(
                      "~/Vendor/moment/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            // bootstrap css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/font-awesome.css",
                      "~/Content/superfish.css",                      
                      "~/Content/style.css",
                      "~/Content/green.css",
                      "~/Content/theme-responsive.css"));


            // Datepicker
            bundles.Add(new ScriptBundle("~/bundles/datepicker/js").Include(
                      "~/Scripts/bootstrap-datepicker.min.js"));

            // Datepicker style
            bundles.Add(new StyleBundle("~/bundles/datepicker/css").Include(
                      "~/Content/bootstrap-datepicker3.min.css"));


        }
    }
}
