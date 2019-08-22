using System.Web;
using System.Web.Optimization;

namespace JobCardSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/coreJs").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Content/Assets/js/bootstrap.js",
                "~/Content/Global/js/main/bootstrap.bundle.min.js",
                "~/Content/Global/js/plugins/loaders/blockui.min.js",
                "~/Content/Global/js/plugins/ui/ripple.min.js",
                "~/Scripts/chosen.jquery.js",
                "~/Scripts/typeahead.bundle.js",
                "~/Content/Assets/js/app.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/themeJs").Include(
                "~/Content/Global/js/plugins/visualization/d3/d3.min.js",
                "~/Content/Global/js/plugins/visualization/d3/d3_tooltip.js",
                "~/Content/Global/js/plugins/forms/styling/switchery.min.js",
                "~/Content/Global/js/plugins/forms/selects/bootstrap_multiselect.js",
                "~/Content/Global/js/plugins/ui/moment/moment.min.js",
                "~/Content/Global/js/plugins/pickers/daterangepicker.js",
                "~/Content/Global/js/demo_pages/dashboard.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/formSelect").Include(
                "~/Content/Global/js/plugins/extensions/jquery_ui/interactions.min.js",
                "~/Content/Global/js/plugins/forms/selects/select2.min.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Assets/css/typeahead.css",
                      "~/Content/site.css"
                      ));
        }
    }
}
