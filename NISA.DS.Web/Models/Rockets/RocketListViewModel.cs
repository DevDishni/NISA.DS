using NISA.DS.Web.Models.Astronauts;
using System.ComponentModel.DataAnnotations;

namespace NISA.DS.Web.Models.Rockets
{
    public class RocketListViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [Display(Name = "Astronaut")]
        public string AstronautFullName { get; set; }
    }
}
