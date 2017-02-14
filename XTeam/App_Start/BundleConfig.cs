using System.Web.Optimization;

namespace XTeam
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/Sweetalert/sweetalert.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                        "~/Scripts/Vue/vue.js",
                        "~/Scripts/Vue/vue-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/codemirror").Include(
                        "~/Scripts/Codemirror/codemirror.js",
                        "~/Scripts/Codemirror/show-hint.js",
                        "~/Scripts/Codemirror/sql-hint.js",
                        "~/Scripts/Codemirror/sql.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Content/Sweetalert/sweetalert.min.css",
                "~/Content/Codemirror/codemirror.css",
                "~/Content/Codemirror/show-hint.css"));
        }
    }
}
