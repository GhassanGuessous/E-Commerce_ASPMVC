using System.Web;
using System.Web.Optimization;

namespace E_Commerce
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*",
                "~/Content/sweetalert/sweetalert.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            // template one ::
            //styles ::
            bundles.Add(new StyleBundle("~/Content/TemplateOne").Include(
                     "~/Content/templateOne/bootstrap.min.css",
                     "~/Content/templateOne/animate.min.css",
                     "~/Content/templateOne/et-line.css",
                     "~/Content/templateOne/icofont.css",
                     "~/Content/templateOne/fontawesome-all.min.css",
                     "~/Content/templateOne/YouTubePopUp.css",
                     "~/Content/templateOne/magnific-popup.css",
                     "~/Content/templateOne/owl.carousel.min.css",
                     "~/Content/templateOne/owl.theme.default.min.css",
                     "~/Content/templateOne/helper.css",
                     "~/Content/templateOne/style.css",
                     "~/Content/templateOne/custom.css",
                     "~/Content/popup/mesStyles.css",
                     "~/Content/templateOne/fontGoogleApi.css",
                     "~/Content/sweetalert/sweetalert.min.css"
                     ));

            //scripts ::
            bundles.Add(new ScriptBundle("~/bundles/TemplateOne").Include(
                    "~/Scripts/TemplateOne/jquery-3.0.0.min.js",
                    "~/Scripts/TemplateOne/jquery-migrate-3.0.0.min.js",
                    "~/Scripts/TemplateOne/popper.min.js",
                    "~/Scripts/TemplateOne/bootstrap.min.js",
                     "~/Scripts/TemplateOne/scrollIt.min.js",
                     "~/Scripts/TemplateOne/animated.headline.js",
                     "~/Scripts/TemplateOne/jquery.waypoints.min.js",
                     "~/Scripts/TemplateOne/jquery.counterup.min.js",
                     "~/Scripts/TemplateOne/owl.carousel.min.js",
                     "~/Scripts/TemplateOne/jquery.magnific-popup.min.js",
                     "~/Scripts/TemplateOne/jquery.stellar.min.js",
                     "~/Scripts/TemplateOne/isotope.pkgd.min.js",
                     "~/Scripts/TemplateOne/YouTubePopUp.jquery.js",
                     "~/Scripts/TemplateOne/map.js",
                     "~/Scripts/TemplateOne/scripts.js"
                     ));

            // Commande
            bundles.Add(new ScriptBundle("~/bundles/CommandeAjax").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Url/https://unpkg.com/sweetalert/dist/sweetalert.min.js",
                "~/Scripts/commandeJs.js"));

        }
    }
}
