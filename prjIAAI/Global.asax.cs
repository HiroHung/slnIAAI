using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebGrease;

namespace prjIAAI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        #region "若是上傳檔案大於4MB，便轉至警告頁"
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpRuntimeSection section = (HttpRuntimeSection)ConfigurationManager.GetSection("system.web/httpRuntime");
            int maxFileSize = section.MaxRequestLength * 1024;
            if (Request.ContentLength > maxFileSize)
            {
                try
                {
                    Response.Redirect("~/Admin/Home/SizeError");
                }
                catch (Exception ex)
                {

                }
            }
        }
        #endregion
    }
}
