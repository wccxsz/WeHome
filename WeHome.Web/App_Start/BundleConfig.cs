using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;
using WeHome.Web.LocalClass;

namespace WeHome.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            var styleBundle = new StyleBundle("~/Assets/CommonStyle")
                .Include("~/assets/global/plugins/font-awesome/css/font-awesome.min.css")
                .Include("~/assets/global/plugins/simple-line-icons/simple-line-icons.min.css")
                .Include("~/assets/global/plugins/bootstrap/css/bootstrap.min.css")
                .Include("~/assets/global/plugins/uniform/css/uniform.default.min.css")
                .Include("~/assets/global/plugins/bootstrap-toastr/toastr.min.css")
                .Include("~/assets/global/css/components.css")
                .Include("~/assets/global/css/plugins.css")
                .Include("~/assets/admin/layout/css/layout.css")
                .Include("~/assets/admin/layout/css/themes/default.css")
                .Include("~/assets/admin/layout/css/custom.css");

            styleBundle.Transforms.Add(new CssUrlTransform());
            bundles.Add(styleBundle);


            var scriptsBundles = new ScriptBundle("~/assets/scripts")
                .Include("~/assets/global/plugins/jquery.min.js")
                .Include("~/assets/global/plugins/jquery-migrate.min.js")
                .Include("~/assets/global/plugins/bootstrap/js/bootstrap.min.js")
                .Include("~/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js")
                .Include("~/assets/global/plugins/bootstrap-toastr/toastr.min.js")
                .Include("~/assets/global/plugins/jquery-validation/js/jquery.validate.min.js")
                .Include("~/assets/global/plugins/backstretch/jquery.backstretch.min.js");
            scriptsBundles.Orderer = new NonOrderingBundleOrderer();

            bundles.Add(scriptsBundles);
            var angularJsBundles = new ScriptBundle("~/Assets/AngularJS")
                .Include("~/assets/global/plugins/angularjs/angular.min.js")
                .Include("~/assets/global/plugins/angularjs/angular-touch.min.js")
                .Include("~/assets/global/plugins/angularjs/plugins/angular-ui-router.min.js")
                .IncludeDirectory("~/Scripts/Controllers", "*.js")
                .IncludeDirectory("~/Scripts/Factories", "*.js")
                .Include("~/Scripts/HomeApp.js");
            angularJsBundles.Orderer = new NonOrderingBundleOrderer();
            bundles.Add(angularJsBundles);
            BundleTable.EnableOptimizations = true;

        }
    }
}
