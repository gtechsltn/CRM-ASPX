using System.Collections.Generic;
using WebApplication1.DTO;

namespace WebApplication1.Business
{
    public interface ICustomerService
    {
        (string, IEnumerable<CustomerModel>) GetCustomerByOwner(string userName);
    }
}