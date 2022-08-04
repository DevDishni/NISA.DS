using NISA.DS.Web.Models.Rockets;

namespace NISA.DS.Web.Models.Trip
{
    public class TripListViewModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string FromPlanet { get; set; }
        public string ToPlanet { get; set; }
        public string TripTypeTicket { get; set; }
    }
}
