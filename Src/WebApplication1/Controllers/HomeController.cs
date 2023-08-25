using log4net;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Business;
using WebApplication1.DTO;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ICryptoService _cryptoService;
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public HomeController(ICryptoService cryptoService, IAccountService accountService, ICustomerService customerService)
        {
            _cryptoService = cryptoService;
            _accountService = accountService;
            _customerService = customerService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var userName = loginViewModel.UserName;
                var password = loginViewModel.Password;
                var (errorMsg, loginSuccess) = _accountService.Login(userName, password);
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    logger.Error(errorMsg);
                    ModelState.AddModelError("", "Có lỗi trong quá trình xử lý. Vui lòng liên hệ admin và quay lại trong thời gian tới.");
                }
                if (loginSuccess)
                {
                    FormsAuthentication.SetAuthCookie(userName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
                }
            }
            return View();
        }

        public ActionResult Index()
        {
            // Retrieve the current user's username
            string owner = System.Web.HttpContext.Current.User.Identity.Name;
            Debug.WriteLine($"Owner: {owner}");

            // Retrieve the current user's username
            string userName = User.Identity.Name;
            Debug.WriteLine($"UserName: {userName}");

            // Check if the user is authenticated
            bool isAuthenticated = User.Identity.IsAuthenticated;
            Debug.WriteLine($"IsAuthenticated: {isAuthenticated}");

            string passwordPlainText = "Abc@123$";
            string passwordEncrypted = _cryptoService.Encrypt(passwordPlainText);
            Debug.WriteLine(passwordEncrypted); // => "LMANlCOGRZSajDZOn18GDA=="

            string password = _cryptoService.Decrypt(passwordEncrypted);
            Debug.WriteLine(password); // => "Abc@123$"

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Debug.WriteLine(connectionString); // => Data Source=localhost;Initial Catalog=CRMS;Integrated Security=SSPI;MultipleActiveResultSets=True

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

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}