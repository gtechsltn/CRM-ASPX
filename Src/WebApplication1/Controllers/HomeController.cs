using log4net;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Web.Mvc;
using WebApplication1.Business;
using WebApplication1.DTO;
using WebApplication1.Infrastructure;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ICryptoService _cryptoService;
        private readonly ICustomerService _customerService;

        public HomeController(ICryptoService cryptoService, ICustomerService customerService)
        {
            _cryptoService = cryptoService;
            _customerService = customerService;
        }

        [Authorize]
        public ActionResult Index()
        {
            // Retrieve the current user's username
            string owner = System.Web.HttpContext.Current.User.Identity.Name;
            Debug.WriteLine($"Owner: {owner}");
            logger.Info($"Owner: {owner}");

            // Retrieve the current user's username
            string userName = User.Identity.Name;
            Debug.WriteLine($"UserName: {userName}");
            logger.Info($"UserName: {userName}");

            // Check if the user is authenticated
            bool isAuthenticated = User.Identity.IsAuthenticated;
            Debug.WriteLine($"IsAuthenticated: {isAuthenticated}");
            logger.Info($"IsAuthenticated: {isAuthenticated}");

            string passwordPlainText = "Abc@123$";
            string passwordEncrypted = _cryptoService.Encrypt(passwordPlainText);
            Debug.WriteLine(passwordEncrypted); // => "LMANlCOGRZSajDZOn18GDA=="
            logger.Info(passwordEncrypted); // => "LMANlCOGRZSajDZOn18GDA=="

            string password = _cryptoService.Decrypt(passwordEncrypted);
            Debug.WriteLine(password); // => "Abc@123$"
            logger.Info(password); // => "Abc@123$"

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Debug.WriteLine(connectionString); // => Data Source=localhost;Initial Catalog=CRMS;Integrated Security=SSPI;MultipleActiveResultSets=True
            logger.Info(connectionString); // => Data Source=localhost;Initial Catalog=CRMS;Integrated Security=SSPI;MultipleActiveResultSets=True

            var (errorMsg, lst) = _customerService.GetCustomerByOwner(userName);
            if (string.IsNullOrEmpty(errorMsg))
            {
                return View(lst);
            }
            return View(new List<CustomerModel>());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}