namespace KSS.HorseRacing.App_Start
{
    using System.Web.Optimization;

    public class BundlesConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrapJs").Include(
                        "~/Scripts/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval-unob").Include(
                "~/Scripts/jquery.validate.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                        "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/css/bootstrapCss").Include(
                        "~/Content/bootstrap.*",
                        "~/Content/bootstrap-responsive*"));

            bundles.Add(new StyleBundle("~/css/custom").Include("~/Content/custom.*"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}