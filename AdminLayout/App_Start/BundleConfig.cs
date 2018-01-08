using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AdminLayout.App_Start
{
    //json.net
    //WebGrease
    //Asp.Net Wep Optimization Framework
    // yukarıdaki 3 paketi indir.
    public class BundleConfig
    {
          public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/bundles/styles").IncludeDirectory("~/Content/Admin/css", "*.css",true));

            bundles.Add(new ScriptBundle("~/bundles/scripts").IncludeDirectory("~/Content/Admin/js", "*.js",true));
            BundleTable.EnableOptimizations = true;
        }
            
    }
}