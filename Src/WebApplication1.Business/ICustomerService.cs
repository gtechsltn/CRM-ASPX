using System.Collections.Generic;
using WebApplication1.DTO;

namespace WebApplication1.Business
{
    public interface ICustomerService
    {
        (string, CustomerDto) GetCustomerById(int customerId, string userName);

        (string, IEnumerable<CustomerModel>) GetCustomersByOwner(string userName);

        (string errorMsg, bool saveSuccess) SaveCustomer(CustomerModel model, string userName);
    }
}