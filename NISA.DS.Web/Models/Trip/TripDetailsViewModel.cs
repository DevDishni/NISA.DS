using NISA.DS.Web.Models.Passengers;
using NISA.DS.Web.Models.Rockets;
using System.ComponentModel.DataAnnotations;

namespace NISA.DS.Web.Models.Trip
{
    public class TripDetailsViewModel
    {
        public TripDetailsViewModel()
        {
            Passengers = new List<PassengerListViewModel>();
        }

        public int Id { get; set; }
        public double Price { get; set; }


        [Display(Name = "From Planet")]
        public string FromPlanet { get; set; }


        [Display(Name = "To Planet")]
        public string ToPlanet { get; set; }


        [Display(Name = "Pick up Date Time")]
        public DateTime PickUpDateTime { get; set; }


        [Display(Name = "Ticket Type")]
        public string TripTypeTicket { get; set; }
        public RocketDetailsViewModel Rocket { get; set; }


        public List<PassengerListViewModel> Passengers { get; set; }
    }
}
