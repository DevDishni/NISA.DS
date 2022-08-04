using NISA.DS.Entities;
using NISA.DS.Web.Models.TripTypes;
using AutoMapper;

namespace NISA.DS.Web.AutoMapperProfiles
{
    public class TripTypeAutoMapperProfile : Profile
    {
        public TripTypeAutoMapperProfile()
        {
            CreateMap<TripType, TripTypeViewModel>().ReverseMap();
        }
    }
}
