using System.Collections.Generic;
using WebApplication1.DTO;

namespace WebApplication1.DataAccess
{
    public interface ICustomerDataAccess
    {
        (string, IEnumerable<CustomerDto>) GetCustomerByOwner(string userName);
    }
}