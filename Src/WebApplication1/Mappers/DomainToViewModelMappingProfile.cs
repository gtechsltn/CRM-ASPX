using AutoMapper;
using System;
using WebApplication1.DTO;
using WebApplication1.Infrastructure;

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
            Mapper.CreateMap<CustomerDto, CustomerModel>()
                .ForMember(x => x.Gender, opt => opt.MapFrom(source => source.Gender.MakeGender()))
                .ForMember(x => x.DoB, opt => opt.MapFrom(source => source.DoB.HasValue ? source.DoB.Value.Date : DateTime.Now))
                .ForMember(x => x.DoBInStr, opt => opt.MapFrom(source => source.DoB.HasValue ? source.DoB.Value.ShowDateOnly() : string.Empty));
        }
    }
}