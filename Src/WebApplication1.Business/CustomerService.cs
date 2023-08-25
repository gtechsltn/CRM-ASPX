using AutoMapper;
using System.Collections.Generic;
using WebApplication1.DataAccess;
using WebApplication1.DTO;
using WebApplication1.Infrastructure;

namespace WebApplication1.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDataAccess _customerDataAccess;

        public CustomerService(ICustomerDataAccess customerDataAccess)
        {
            _customerDataAccess = customerDataAccess;
        }

        public (string, CustomerDto) GetCustomerById(int customerId, string userName)
        {
            return _customerDataAccess.GetCustomerById(customerId, userName);
        }

        public (string, IEnumerable<CustomerModel>) GetCustomerByOwner(string userName)
        {
            var (errorMsg, dtos) = _customerDataAccess.GetCustomerByOwner(userName);
            if (string.IsNullOrWhiteSpace(errorMsg))
            {
                var lst = MapToListCustomerModel(dtos);
                return (string.Empty, lst);
            }
            return (errorMsg, null);
        }

        private IEnumerable<CustomerModel> MapToListCustomerModel(IEnumerable<CustomerDto> dtos)
        {
            var lst = new List<CustomerModel>();
            foreach (var dto in dtos)
            {
                var model = Mapper.Map<CustomerModel>(dto);
                model.DoBInStr = model.DoB.ShowDateOnly();
                model.Gender = model.Gender.MakeGender();
                lst.Add(model);
            }
            return lst;
        }
    }
}