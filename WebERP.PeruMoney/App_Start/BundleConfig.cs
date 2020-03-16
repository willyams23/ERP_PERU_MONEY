using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebERP.PeruMoney
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/vendor/fontawesome-free/css/all.min.css",
                "~/Content/css/sb-admin-2.css",
                //"~/Content/css/sb-admin-2.min.css",
                "~/Content/css/sb-admin-3.css"));

            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/js/sb-admin-2.min.js",
                "~/Content/vendor/chart.js/Chart.min.js",
                "~/Content/js/demo/chart-area-demo.js",
                "~/Content/js/demo/chart-pie-demo.js"));
        }
        public static void RegisterLoginBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundlesLogin/css")
                 .Include(
                 "~/Content_Login/vendor/bootstrap/css/bootstrap.min.css",
                 "~/Content_Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                 "~/Content_Login/fonts/iconic/css/material-design-iconic-font.min.css",
                 "~/Content_Login/vendor/animate/animate.css",
                 "~/Content_Login/vendor/css-hamburgers/hamburgers.min.css",
                 "~/Content_Login/vendor/animsition/css/animsition.min.css",
                 "~/Content_Login/vendor/select2/select2.min.css",
                 "~/Content_Login/vendor/daterangepicker/daterangepicker.css",
                 "~/Content_Login/css/util.css",
                 "~/Content_Login/css/main.css"));

            bundles.Add(new ScriptBundle("~/bundlesLogin/js")
                .Include(
                "~/Content_Login/vendor/jquery/jquery-3.2.1.min.js",
                "~/Content_Login/vendor/animsition/js/animsition.min.js",
                "~/Content_Login/vendor/bootstrap/js/popper.js",
                "~/Content_Login/vendor/bootstrap/js/bootstrap.min.js",
                "~/Content_Login/vendor/select2/select2.min.js",
                "~/Content_Login/vendor/daterangepicker/moment.min.js",
                "~/Content_Login/vendor/daterangepicker/daterangepicker.js",
                "~/Content_Login/vendor/countdowntime/countdowntime.js",
                "~/Content_Login/js/main.js"));
        }
    }
}