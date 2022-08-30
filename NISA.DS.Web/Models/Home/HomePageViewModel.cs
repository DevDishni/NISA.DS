using NISA.DS.Web.Models.Trip;

namespace NISA.DS.Web.Models.Home
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            Trips = new List<TripListViewModel>();
        }

        public List<TripListViewModel> Trips { get; set; }
    }
}
