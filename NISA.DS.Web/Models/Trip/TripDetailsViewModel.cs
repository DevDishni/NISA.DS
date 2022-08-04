using NISA.DS.Web.Models.Passengers;
using NISA.DS.Web.Models.Rockets;

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
        public string FromPlanet { get; set; }
        public string ToPlanet { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public string TripTypeTicket { get; set; }
        public RocketDetailsViewModel Rocket { get; set; }


        public List<PassengerListViewModel> Passengers { get; set; }
    }
}
