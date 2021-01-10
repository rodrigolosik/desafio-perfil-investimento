using System.Web.Optimization;

namespace PerfilInvestidor.Apresentacao
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.4.1/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery-validate/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/bootstrap.js",
                      "~/Content/template/plugins/bootstrap/js/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/template/styles").Include(
                "~/Content/template/dist/css/adminlte.min.css"));

            bundles.Add(new ScriptBundle("~/template/scripts").Include(
                "~/Content/template/dist/js/adminlte.min.js"));

            bundles.Add(new StyleBundle("~/template/plugins/styles").Include(
                "~/Content/template/plugins/fontawesome-free/css/all.min.css",
                "~/Content/template/plugins/icheck-bootstrap/icheck-bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/plugins/scripts").Include(
                "~/Content/template/plugins/toastr/toastr.min.js",
                "~/Content/template/plugins/sweatalert2/sweatalert2.min.js"));

            bundles.Add(new StyleBundle("~/plugins/styles").Include(
                "~/Content/template/plugins/toastr/toastr.min.css",
                "~/Content/template/plugins/sweatalert2/sweatalert2.min.css"));
        }
    }
}
