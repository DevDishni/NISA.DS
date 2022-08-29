using NISA.DS.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NISA.DS.Entities
{
    public class Trip
    {
        public Trip()
        {
            Passengers = new List<Passenger>();
        }

        public int Id { get; set; }
        public double Price { get; set; }
        public string FromPlanet { get; set; }
        public string ToPlanet { get; set; }
        public DateTime PickUpDateTime { get; set; }


        public int RocketId { get; set; }
        public Rocket Rocket { get; set; }

        public TicketType TicketType { get; set; }

        public int TripTypeId { get; set; }
        public TripType TripType { get; set; }

        public List<Passenger> Passengers { get; set; }

    }
}
