using log4net;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Business;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Customer")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerApiController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly ICustomerService _customerService;

        public CustomerApiController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            logger.Info(nameof(Get));
            var (errorMsg, dto) = _customerService.GetCustomerById(1, User.Identity.Name);
            return string.IsNullOrEmpty(errorMsg) ? Ok(dto) : Ok(new CustomerDto());
        }

        [HttpGet]
        [Route("Get/{id:int}")]
        public IHttpActionResult GetById(int id = 1)
        {
            logger.Info(nameof(GetById));
            var (errorMsg, dto) = _customerService.GetCustomerById(id, User.Identity.Name);
            return string.IsNullOrEmpty(errorMsg) ? Ok(dto) : Ok(new CustomerDto());
        }
    }
}