using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NISA.DS.Web.Models.Rockets
{
    public class RocketViewModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }


        [Display(Name = "Rocket Full Name")]
        [ValidateNever]
        public string RocketFullName { get; set; }


        [Display(Name = "Number of Seats")]
        public int NumberOfSeats { get; set; }


        [Display(Name = "Production Date")]
        public DateTime? ProductionDate { get; set; }


        [Display(Name = "Astronaut")]
        public int AstronautId { get; set; }

        [ValidateNever]
        public SelectList Astronauts { get; set; }
    }
}
