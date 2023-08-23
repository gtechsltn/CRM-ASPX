using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Mvc;
using WebApplication1.Infrastructure;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICryptoService _cryptoService;

        public HomeController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public ActionResult Index()
        {
            string passwordPlainText = "Abc@123$";
            string password = _cryptoService.Encrypt(passwordPlainText);
            Debug.WriteLine(password); // => "LMANlCOGRZSajDZOn18GDA=="

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Debug.WriteLine(connectionString); // => Data Source=localhost;Initial Catalog=CRMS;Integrated Security=SSPI;MultipleActiveResultSets=True

            string cmdText = "SELECT TOP 10 [Id],[UserName],[Password] FROM [dbo].[User]";
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