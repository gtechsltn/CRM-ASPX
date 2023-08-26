﻿using AutoMapper;
using log4net;
using System.Reflection;
using System.Web.Mvc;
using WebApplication1.Business;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult Edit(int customerId)
        {
            logger.Info(nameof(Edit));
            var (errorMsg, dto) = _customerService.GetCustomerById(customerId, User.Identity.Name);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                logger.Error(errorMsg);
            }
            return Json(string.IsNullOrEmpty(errorMsg) ? dto :
                new CustomerDto(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDataForEdit(int customerId)
        {
            logger.Info(nameof(GetDataForEdit));
            var (errorMsg, dto) = _customerService.GetCustomerById(customerId, User.Identity.Name);
            var model = new CustomerModel();
            if (string.IsNullOrEmpty(errorMsg))
            {
                model = Mapper.Map<CustomerModel>(dto);
            }
            string viewContent = this.ConvertViewToString("_EditCustomer", model);
            return Content(viewContent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerModel model)
        {
            logger.Info(nameof(Save));
            var (errorMsg, saveSuccess) = _customerService.SaveCustomer(model, User.Identity.Name);
            if (!string.IsNullOrEmpty(errorMsg))
            {
                logger.Error(errorMsg);
            }
            return Json(saveSuccess, JsonRequestBehavior.AllowGet);
        }
    }
}