using NISA.DS.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace NISA.DS.Web.Models.Passengers
{
    public class PassengerDetailsViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int NNS { get; set; }


        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
