using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Domain
{
    public class Flight
    {
        //public Flight(int flightId, DateTime flightDate)
        //{
        //    FlightId = flightId;
        //    FlightDate = flightDate;
        //}
        //public Flight()
        //{
            
        //}

        //prop de base
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set;}
        //prop de navigation: propriete qui modelise une relation entre 2 entité(sont des listes et des objets)
        public ICollection<Passenger> Passengers { get; set; }
        public Plane Plane { get; set; }
        public override string ToString()
        {
            return "Destination: "+Destination+" Date: "+FlightDate+" Duree: "+EstimatedDuration;
        }
    }
}
