using AutoMapper;
using NISA.DS.Entities;
using NISA.DS.Web.Models.Passengers;

namespace NISA.DS.Web.AutoMapperProfiles
{
    public class PassengerAutoMapperProfile : Profile
    {
        public PassengerAutoMapperProfile()
        {
            CreateMap<Passenger, PassengerListViewModel>();
            CreateMap<Passenger, PassengerDetailsViewModel>();
            CreateMap<Passenger, PassengerViewModel>().ReverseMap();
        }
    }
}
