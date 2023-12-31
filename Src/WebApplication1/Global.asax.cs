using log4net;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            logger.Info("");
            logger.Info("=========================================================================================================");

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Configure Unity.Mvc5
            UnityConfig.RegisterComponents();

            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();

            //log the error!
            logger.Error(ex);
        }
    }
}