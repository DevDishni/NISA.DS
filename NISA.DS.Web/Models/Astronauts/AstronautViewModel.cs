using NISA.DS.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace NISA.DS.Web.Models.Astronauts
{
    public class AstronautViewModel
    {
        public int Id { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        public int Rating { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int NNS { get; set; }


        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
