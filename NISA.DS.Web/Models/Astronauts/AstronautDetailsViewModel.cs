using NISA.DS.Utils.Enums;
using NISA.DS.Web.Models.Rockets;
using System.ComponentModel.DataAnnotations;

namespace NISA.DS.Web.Models.Astronauts
{
    public class AstronautDetailsViewModel
    {
        public AstronautDetailsViewModel()
        {
            Rockets = new List<RocketListViewModel>();
        }

        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        public int Age { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Identification Number")]
        public int IdentificationNumber { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        public List<RocketListViewModel> Rockets { get; set; }
    }
}
