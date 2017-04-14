using NLog;
using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TwitterTestApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.Register();

            logger.Info("Application started");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            logger.Error(exception);
        }
    }
}
