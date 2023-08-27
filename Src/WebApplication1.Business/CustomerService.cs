using AutoMapper;
using System.Collections.Generic;
using WebApplication1.DataAccess;
using WebApplication1.DTO;

namespace WebApplication1.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDataAccess _customerDataAccess;
        private readonly IConverterService _converterService;

        public CustomerService(ICustomerDataAccess customerDataAccess, IConverterService converterService)
        {
            _customerDataAccess = customerDataAccess;
            _converterService = converterService;
        }

        public (string, CustomerDto) GetCustomerById(int customerId, string userName)
        {
            return _customerDataAccess.GetCustomerById(customerId, userName);
        }

        public (string, IEnumerable<CustomerModel>) GetCustomersByOwner(string userName)
        {
            var (errorMsg, dtos) = _customerDataAccess.GetCustomersByOwner(userName);
            if (string.IsNullOrWhiteSpace(errorMsg))
            {
                var lst = MapToModels(dtos);
                return (string.Empty, lst);
            }
            return (errorMsg, null);
        }

        public (string errorMsg, bool saveSuccess) SaveCustomer(CustomerModel model, string userName)
        {
            var dto = Mapper.Map<CustomerDto>(model);
            dto.Gender = _converterService.MakeGenderInDB(model.Gender);
            dto.DoB = _converterService.GetDate(model.DoBInStr);
            dto.Owner = userName;
            MakeSureDtoHasRequiredFields(dto);
            return _customerDataAccess.SaveCustomer(dto);
        }

        private void MakeSureDtoHasRequiredFields(CustomerDto dto)
        {
            if (dto.Id > 0)
            {
                var (errorMsg, customerDB) = _customerDataAccess.GetCustomerById(dto.Id, dto.Owner);
                if (string.IsNullOrWhiteSpace(errorMsg) && customerDB.Id > 0)
                {
                    if (string.IsNullOrWhiteSpace(dto.CCCD)) dto.CCCD = customerDB.CCCD;
                    if (string.IsNullOrWhiteSpace(dto.CMND)) dto.CMND = customerDB.CMND;
                    if (string.IsNullOrWhiteSpace(dto.Address)) dto.Address = customerDB.Address;
                    if (string.IsNullOrWhiteSpace(dto.Email)) dto.Email = customerDB.Email;
                    if (string.IsNullOrWhiteSpace(dto.Mobile)) dto.Mobile = customerDB.Mobile;
                    if (string.IsNullOrWhiteSpace(dto.Gender)) dto.Gender = customerDB.Gender;
                    if (string.IsNullOrWhiteSpace(dto.Facebook)) dto.Facebook = customerDB.Facebook;
                    if (string.IsNullOrWhiteSpace(dto.Hobbies)) dto.Hobbies = customerDB.Hobbies;
                    if (string.IsNullOrWhiteSpace(dto.Note)) dto.Note = customerDB.Note;
                    if (string.IsNullOrWhiteSpace(dto.Owner)) dto.Owner = customerDB.Owner;
                }
            }
        }

        private IEnumerable<CustomerModel> MapToModels(IEnumerable<CustomerDto> dtos)
        {
            var lst = new List<CustomerModel>();
            foreach (var dto in dtos)
            {
                var model = Mapper.Map<CustomerModel>(dto);
                model.Gender = _converterService.MakeGenderInScreen(dto.Gender);
                model.DoBInStr = _converterService.ShowDateOnly(dto.DoB);
                lst.Add(model);
            }
            return lst;
        }
    }
}