using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NISA.DS.Entities
{
    public class Rocket
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime ProductionDate { get; set; }


        public int AstronautId { get; set; }
        public Astronaut? Astronaut { get; set; }


        [NotMapped]
        public string RocketFullName
        {
            get
            {
                return $"{Brand} {Model}";
            }
        }
    }
}
