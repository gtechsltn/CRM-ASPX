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
            //Mapper.CreateMap<CustomerDto, CustomerViewModel>();
            //    .ForMember(x => x.SupportsCount, opt => opt.MapFrom(source => source.Supports.Count))
            //    .ForMember(x => x.UserName, opt => opt.MapFrom(source => source.User.UserName))
            //    .ForMember(x => x.StartDate, opt => opt.MapFrom(source => source.StartDate.ToString("dd MMM yyyy")))
            //    .ForMember(x => x.EndDate, opt => opt.MapFrom(source => source.EndDate.ToString("dd MMM yyyy")));
        }
    }
}