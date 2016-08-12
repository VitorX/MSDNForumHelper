using System.Web;
using System.Web.Optimization;

namespace ForumHelper.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //         "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/bundles/css/siteCss").IncludeDirectory(
                   "~/Content","*.css"));
            bundles.Add(new ScriptBundle("~/bundles/ForumHelperApp")
                    .IncludeDirectory("~/Scripts/Controllers", "*.js")
                    .Include("~/Scripts/ForumHelperApp.js")
                    .Include("~/Scripts/ui-bootstrap.js")
                    .Include("~/Scripts/ui-bootstrap-tpls.js"));
            BundleTable.EnableOptimizations = true;

        }
    }
}
