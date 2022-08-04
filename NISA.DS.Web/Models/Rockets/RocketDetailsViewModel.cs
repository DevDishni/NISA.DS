using NISA.DS.Web.Models.Astronauts;
using System.ComponentModel.DataAnnotations;

namespace NISA.DS.Web.Models.Rockets
{
    public class RocketDetailsViewModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }


        [Display(Name = "Number of Seats")]
        public int NumberOfSeats { get; set; }


        [Display(Name = "Production Date")]
        public DateTime ProductionDate { get; set; }


        [Display(Name = "Astronaut")]
        public string AstronautFullName { get; set; }
    }
}
