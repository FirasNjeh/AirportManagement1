using AM1.ApplicationCore.Domain;
using AM1.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Services
{
    public class FlightMethods :IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlight()
        {
            var req= from f in Flights
                     group f by f.Destination;
            foreach (var g in req)
            {
                Console.WriteLine(g.Key);
                foreach(var f in g)
                    Console.WriteLine(f);
            }
            return req;
        }

        public double DurationAverage(string destination)
        {
            var req= from f in Flights
                     where f.Destination == destination
                     select f.EstimatedDuration;
            return req.Average();
        }

        public IList<DateTime> GetFlightDates(string destination)
        {
            IList < DateTime > dateTimes = new List<DateTime>();
            //Parcours la liste des flight dans la liste flights comme for 
            //foreach (Flight f in Flights)
            //{
            //    if (f.Destination == destination)
            //    {
            //        dateTimes.Add(f.FlightDate);
            //        Console.WriteLine(f.FlightDate);
            //    }
            //}
            //Transforme un type enumerable en liste
            dateTimes=(from f in Flights
                      where f.Destination == destination
                      select f.FlightDate).ToList();
            return dateTimes;
             
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch(filterType)
            {
                case "Destination":
                    {
                        foreach (Flight f in Flights)
                        
                            if(f.Destination.Equals(filterValue))
                            
                                Console.WriteLine(f);
                            
                        break;
                    }
                case "Departure":
                    {
                        foreach (Flight f in Flights)

                            if (f.Departure.Equals(filterValue))

                                Console.WriteLine(f);

                        break;
                    }
                case "FlightDate":
                    {
                        foreach (Flight f in Flights)
                            //DateTime.Parse convertit un string en datetime

                            if (f.FlightDate.Equals(DateTime.Parse(filterValue)))

                                Console.WriteLine(f);

                        break;
                    }
                case "EstimatedDuration":
                    {
                        foreach (Flight f in Flights)

                            if (f.EstimatedDuration.Equals(int.Parse(filterValue)))

                                Console.WriteLine(f);

                        break;
                    }
            }
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req= from f in Flights
                     orderby f.EstimatedDuration descending
                     select f;
            return req;
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req= from f in Flights
                      //DateTime.Compare(t1,t2) retourne un entier negatif si t1<t2 sinon un entier positif si t1=t2 retourne 0
                     where DateTime.Compare(startDate,f.FlightDate)<0
                     && (f.FlightDate-startDate).TotalDays<=7
                     select f;
            return req.Count();
                     ;
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            var req = from t in flight.Passengers.OfType<Traveller>()
                      orderby t.BirthDate
                      select t;
            //recuperer les 3 premieres occurences
            return req.Take(3);
            //Skip (3) pour ignorer les 3 premieres occruences
                      ;
        }

        public void ShowFlightDetails(Plane plane)
        {
            var req = from f in Flights
                                     where f.Plane == plane
                                     select new {f.Destination,f.FlightDate};
            foreach (var f in req)
                Console.WriteLine(f);

        }
    }
}
