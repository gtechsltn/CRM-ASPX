using log4net;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using WebApplication1.Business;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var (errorMsg, lst) = _customerService.GetCustomersByOwner(User.Identity.Name);
            if (string.IsNullOrEmpty(errorMsg))
            {
                return View(lst);
            }
            logger.Error(errorMsg);
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