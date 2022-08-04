using AutoMapper;
using NISA.DS.Entities;
using NISA.DS.Web.Models.Trip;

namespace NISA.DS.Web.AutoMapperProfiles
{
    public class TripAutoMapperProfile : Profile
    {
        public TripAutoMapperProfile()
        {
            CreateMap<Trip, TripListViewModel>();
            CreateMap<Trip, TripDetailsViewModel>();
            CreateMap<Trip, TripViewModel>().ReverseMap();
        }
    }
}
