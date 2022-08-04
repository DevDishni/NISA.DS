using NISA.DS.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace NISA.DS.Web.Models.Astronauts
{
    public class AstronautListViewModel
    {
        public int Id { get; set; }

        [Display (Name = "Full Name")]
        public string FullName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
