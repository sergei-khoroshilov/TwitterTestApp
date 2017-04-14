using System.Web.Optimization;

namespace TwitterTestApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/content/css").Include(
                      "~/Content/bootstrap.min.css"));
        }
    }
}