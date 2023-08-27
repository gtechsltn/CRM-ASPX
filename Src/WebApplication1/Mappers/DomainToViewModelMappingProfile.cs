using AutoMapper;
using WebApplication1.DTO;

namespace WebApplication1
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CustomerDto, CustomerModel>();
        }
    }
}