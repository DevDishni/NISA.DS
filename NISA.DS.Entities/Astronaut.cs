using NISA.DS.Utils.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NISA.DS.Entities
{
    public class Astronaut
    {
        public Astronaut()
        {
            Rockets = new List<Rocket>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }

        public Gender Gender { get; set; }
        public int NNS { get; set; }
        public string PhoneNumber { get; set; }
        public int Rating { get; set; }

        public List<Rocket> Rockets { get; set; }

        [NotMapped]

        public string FullName
        {

            get
            {
                return $"{FirstName} {LastName}";
            }

        }


        [NotMapped]

        public int Age
        {
            get
            {
                if (DOB.HasValue)
                {
                    return DateTime.Now.Year - DOB.Value.Year;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}