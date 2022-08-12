using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NISA.DS.Web.Models.Trip
{
    public class TripViewModel
    {
        public int Id { get; set; }
        public double Price { get; set; }


        [Display(Name = "From Planet")]
        public string FromPlanet { get; set; }


        [Display(Name = "To Planet")]
        public string ToPlanet { get; set; }


        [Display(Name = "Pick up Date Time")]
        public DateTime? PickUpDateTime { get; set; }


        [Display(Name = "Passengers")]
        public List<int> PassengerIds { get; set; }


        [Display(Name = "Rocket")]
        public int RocketId { get; set; }


        [Display(Name = "Ticket Type")]
        public int TripTypeId { get; set; }



        [ValidateNever]
        public SelectList TripTypes { get; set; }


        [ValidateNever]
        public SelectList Rockets { get; set; }


        [ValidateNever]
        public MultiSelectList PassengersMultiSelect { get; set; }
    }
}
