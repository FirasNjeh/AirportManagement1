using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string AirlineLogo { get; set; }
        //prop de navigation: propriete qui modelise une relation entre 2 entité(sont des listes et des objets)
        //public ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public  virtual Plane Plane { get; set; }
        [ForeignKey("Plane")]
        public int PlaneFK { get; set; } //=> cle primaire de la classe plane c'est la cle etrangere de la classe flight uniqeuement dans les associations one to(one/many)
        //On fait appel à l'attribut plane et sa cle primaire pour y avoir accés directement 
        public override string ToString()
        {
            return "Destination: "+Destination+" Date: "+FlightDate+" Duree: "+EstimatedDuration;
        }
    }
}
