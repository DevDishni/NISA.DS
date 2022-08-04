using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NISA.DS.Web.Models.Trip
{
    public class TripViewModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string FromPlanet { get; set; }
        public string ToPlanet { get; set; }
        public DateTime? PickUpDateTime { get; set; }


        public List<int> PassengerIds { get; set; }
        public int RocketId { get; set; }
        public int TripTypeId { get; set; }



        [ValidateNever]
        public SelectList TripTypes { get; set; }


        [ValidateNever]
        public SelectList Rockets { get; set; }


        [ValidateNever]
        public MultiSelectList PassengersMultiSelect { get; set; }
    }
}
