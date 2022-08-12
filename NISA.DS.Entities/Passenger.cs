using NISA.DS.Utils.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NISA.DS.Entities
{
    public class Passenger
    {
        public Passenger()
        {
            Trips = new List<Trip>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public Gender Gender { get; set; }
        public int NNS { get; set; }
        public string PhoneNumber { get; set; }

        public List<Trip> Trips { get; set; }


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
