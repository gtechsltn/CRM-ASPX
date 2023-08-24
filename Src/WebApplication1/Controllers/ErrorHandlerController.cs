using log4net;
using System.Diagnostics;
using System.Reflection;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ErrorHandlerController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ErrorHandlerController()
        {
        }

        public ActionResult Index(string errorMsg = "")
        {
            logger.Error(errorMsg);

            // Retrieve the current user's username
            string owner = System.Web.HttpContext.Current.User.Identity.Name;
            Debug.WriteLine($"Owner: {owner}");

            // Retrieve the current user's username
            string userName = User.Identity.Name;
            Debug.WriteLine($"UserName: {userName}");

            // Check if the user is authenticated
            bool isAuthenticated = User.Identity.IsAuthenticated;
            Debug.WriteLine($"IsAuthenticated: {isAuthenticated}");

            return View();
        }

        public ActionResult Forbidden()
        {
            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}