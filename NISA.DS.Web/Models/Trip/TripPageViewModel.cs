using Microsoft.AspNetCore.Mvc.Rendering;

namespace NISA.DS.Web.Models.Trip
{
    public class TripPageViewModel
    {

        public TripPageViewModel()
        {
            Trips = new List<TripListViewModel>();
        }
        public List<TripListViewModel> Trips { get; set; }

        public int? TripTypeId { get; set; }
        public SelectList TripTypes { get; set; }
    }
}
