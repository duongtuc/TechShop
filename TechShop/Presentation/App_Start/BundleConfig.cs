using System.Web;
using System.Web.Optimization;

namespace Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/jquery").Include(
               "~/Assets/client/js/jquery.min.js"
          
               ));
            bundles.Add(new ScriptBundle("~/js/plugins").Include(
                "~/bower_components/jquery-ui/jquery-ui.min.js",
                "~/Assets/client/js/jquery.flexisel.js",
                "~/Assets/client/js/jquery.etalage.min.js",
                "~/bower_components/mustache/mustache.js",
                "~/Assets/client/js/common.js",
                "~/bower_components/jquery-validation/dist/jquery.validate.js",
                "~/bower_components/numeral/min/numeral.min.js"
                ));

            bundles.Add(new StyleBundle("~/css/base")
                .Include("~/Assets/client/css/bootstrap.css",new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/style.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/fontawesome.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/custom.css", new CssRewriteUrlTransform())
                .Include("~/bower_components/jquery-ui/themes/smoothness/jquery-ui.min.css", new CssRewriteUrlTransform())
                );
            BundleTable.EnableOptimizations = true;
        }
    }
}
