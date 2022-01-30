using System.Web;
using System.Web.Optimization;

namespace SpaLNT
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/wp-content").Include(
                "~/Content/wp-content/plugins/contact-form-7/includes/js/scripts1748.js",
                "~/Content/wp-content/plugins/fb-messenger/js/indexca80.js",
                "~/Content/wp-content/plugins/ot-flatsome-vertical-menu/assets/js/ot-vertical-menuf488.js",
                "~/Content/wp-content/plugins/woocommerce/assets/js/jquery-blockui/jquery.blockUI.min44fd.js",
                "~/Content/wp-content/plugins/woocommerce/assets/js/frontend/add-to-cart.min9d52.js",
                "~/Content/wp-content/plugins/woocommerce/assets/js/js-cookie/js.cookie.min6b25.js",
                "~/Content/wp-content/plugins/woocommerce/assets/js/frontend/woocommerce.min9d52.js",
                "~/Content/wp-content/plugins/woocommerce/assets/js/frontend/cart-fragments.min9d52.js",
                "~/Content/wp-content/themes/flatsome/inc/extensions/flatsome-live-search/flatsome-live-searchf43b.js",
                "~/Content/wp-content/themes/flatsome/assets/js/flatsomef43b.js",
                "~/Content/wp-content/themes/flatsome/assets/js/woocommercef43b.js",
                "~/Content/wp-content/plugins/woocommerce/assets/js/frontend/password-strength-meter.min9d52.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/wp-includes").Include(
                "~/Content/wp-includes/js/wp-embed.minca80.js",
                "~/Content/wp-includes/js/zxcvbn-async.min5152.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/wp-admin").Include(
                "~/Content/wp-admin/js/password-strength-meter.minca80.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     //"~/Content/css/MainLayoutvVer2.css"
                     "~/Content/bootstrap.css",
                     "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/wp-content").Include(
                     "~/Content/wp-content/plugins/ot-flatsome-vertical-menu/libs/menu-icons/css/extra.mincf86.css",
                     "~/Content/wp-content/plugins/call-now-icon-animate/css.css",
                     "~/Content/wp-content/plugins/contact-form-7/includes/css/styles1748.css",
                     "~/Content/wp-content/plugins/fb-messenger/css/styleca80.css",
                     "~/Content/wp-content/plugins/ot-flatsome-vertical-menu/assets/css/ot-vertical-menuf488.css",
                     "~/Content/wp-content/themes/flatsome/assets/css/fl-icons6de8.css",
                     "~/Content/wp-content/plugins/easy-social-share-buttons3/assets/css/default-retina/easy-social-share-buttons1ac1.css",
                     "~/Content/wp-content/plugins/easy-social-share-buttons3/lib/modules/click-to-tweet/assets/css/styles1ac1.css",
                     "~/Content/wp-content/themes/flatsome/assets/css/flatsomef43b.css",
                     "~/Content/wp-content/themes/flatsome-child/stylef43b.css"));

            bundles.Add(new StyleBundle("~/Content/wp-includes").Include(
                    "~/Content/css/wp-includes/js/jquery/jqueryb8ff.js",
                    "~/Content/css/wp-includes/js/jquery/jquery-migrate.min330a.js",
                    "~/Content/css/wp-includes/wlwmanifest.xml"));


            /*-------------------------------------------Admin----------------------------------*/
            bundles.Add(new StyleBundle("~/Areas/Admin/Content/css").Include(
                    "~/Areas/Admin/Content/css/apexcharts.css",
                    "~/Areas/Admin/Content/css/style.min.css"));

            bundles.Add(new StyleBundle("~/Areas/Admin/Content/css/branches/create").Include(
                "~/Areas/Admin/Content/css/branches/create.css"));

        }
    }
}
