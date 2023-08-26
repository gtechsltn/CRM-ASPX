using System.Collections.Generic;
using WebApplication1.DTO;

namespace WebApplication1.DataAccess
{
    public interface ICustomerDataAccess
    {
        (string, CustomerDto) GetCustomerById(int customerId, string userName);

        (string, IEnumerable<CustomerDto>) GetCustomersByOwner(string userName);

        (string errorMsg, bool saveSuccess) SaveCustomer(CustomerDto model);
    }
}