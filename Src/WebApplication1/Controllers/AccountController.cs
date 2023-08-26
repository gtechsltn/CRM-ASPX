using log4net;
using System;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Business;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl = "")
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
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    // => "Sai tên đăng nhập hoặc mật khẩu"
                    // => "Có lỗi trong quá trình xử lý yêu cầu"
                    ModelState.AddModelError("", errorMsg);
                }
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var (errorMsg, registerSuccess) = _accountService.Register(model.UserName2, model.Password2);
                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        logger.Error(errorMsg);
                    }
                    if (registerSuccess)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", errorMsg);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetDataForRegister()
        {
            logger.Info(nameof(GetDataForRegister));
            var model = new RegisterModel();
            string viewContent = this.ConvertViewToString("_RegisterPartial", model);
            return Content(viewContent);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}