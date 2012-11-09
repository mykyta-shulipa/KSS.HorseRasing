namespace KSS.HorseRacing.App_Start
{
    public class BundlesConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrapJs").Include(
                        "~/js/bootstrap-datepicker.js",
                        "~/js/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery-1.*",
                        "~/js/jquery-ui-1.8.24.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/js/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval-unob").Include(
                "~/js/jquery.validate.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                        "~/js/custom.js",
                        "~/js/jquery.toggle.buttons.js",
                        "~/js/date.js",
                        "~/js/daterangepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/media-element-js").Include(
                "~/mediaelement/mediaelement-and-player.*"));

            bundles.Add(new ScriptBundle("~/bundles/file-upload-js").Include(
                "~/js/jquery.fileupload.js",
                "~/js/canvas-to-blob.min.js",
                "~/js/jquery.fileupload-ip.js",
                "~/js/jquery.iframe-transport.js",
                "~/js/load-image.*",
                "~/js/locale.js",
                "~/js/tmpl.*",
                "~/js/jquery.fileupload-ui.js"));

            bundles.Add(new StyleBundle("~/css/media-element-css").Include(
                "~/mediaelement/mediaelementplayer.*"));

            bundles.Add(new StyleBundle("~/css/file-upload-css").Include(
                "~/css/jquery.fileupload-ui.css"));

            bundles.Add(new StyleBundle("~/css/bootstrapCss").Include(
                        "~/css/bootstrap.*",
                        "~/css/bootstrap-responsive*",
                        "~/css/daterangepicker.css"));

            bundles.Add(new StyleBundle("~/css/font").Include("~/css/font-awesome*"));

            bundles.Add(new StyleBundle("~/css/custom").Include("~/css/custom.css", "~/css/bootstrap-toggle-buttons.css"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}