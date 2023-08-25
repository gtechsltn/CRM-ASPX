using AutoMapper;
using WebApplication1.DTO;

namespace WebApplication1
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CustomerModel, CustomerDto>();
            //Mapper.CreateMap<CustomerViewModel, CustomerDto>();
        }
    }
}