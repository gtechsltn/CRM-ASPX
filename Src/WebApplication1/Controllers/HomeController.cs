using log4net;
using log4net.Repository.Hierarchy;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Business;
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

        public HomeController(ICryptoService cryptoService, IAccountService accountService)
        {
            _cryptoService = cryptoService;
            _accountService = accountService;
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
                }
                if (loginSuccess)
                {
                    FormsAuthentication.SetAuthCookie(userName, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu");
            }
            return View();
        }

        public ActionResult Index()
        {
            string passwordPlainText = "Abc@123$";
            string password = _cryptoService.Encrypt(passwordPlainText);
            Debug.WriteLine(password); // => "LMANlCOGRZSajDZOn18GDA=="

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Debug.WriteLine(connectionString); // => Data Source=localhost;Initial Catalog=CRMS;Integrated Security=SSPI;MultipleActiveResultSets=True

            string cmdText = "SELECT TOP 10 [Id], [UserName], [Password] FROM [dbo].[User]";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0);
                            var userName = reader.GetString(1);
                            var passwordDB = reader.GetString(2);
                            Debug.WriteLine($"Id: {id}, UserName: {userName}, Password: {passwordDB},");
                        }
                    }
                }
            }
            return View();
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