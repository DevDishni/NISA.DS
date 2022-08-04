using AutoMapper;
using NISA.DS.Entities;
using NISA.DS.Web.Models.Astronauts;

namespace NISA.DS.Web.AutoMapperProfiles
{
    public class AstronautAutoMapperProfile : Profile
    {
        public AstronautAutoMapperProfile()
        {
            CreateMap<Astronaut, AstronautListViewModel>();
            CreateMap<Astronaut, AstronautDetailsViewModel>();
            CreateMap<Astronaut, AstronautViewModel>().ReverseMap();
        }
    }
}
