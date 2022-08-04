using AutoMapper;
using NISA.DS.Entities;
using NISA.DS.Web.Models.Rockets;

namespace NISA.DS.Web.AutoMapperProfiles
{
    public class RocketAutoMapperProfile : Profile
    {
        public RocketAutoMapperProfile()
        {
            CreateMap<Rocket, RocketListViewModel>();
            CreateMap<Rocket, RocketDetailsViewModel>();
            CreateMap<Rocket, RocketViewModel>().ReverseMap();
        }
    }
}
