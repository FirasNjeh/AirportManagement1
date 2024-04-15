using AM1.ApplicationCore.Domain;
using AM1.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Plane = AM1.ApplicationCore.Domain.Plane;

namespace AM1.ApplicationCore.Services
{
    public class FlightMethods :IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        //Action pour des methodes qui retourne void ,Flight c'est ce qu'il prend en parametre (on peux avoir plusieurs types de parametre)
        public Action<Plane> FlightDetailsDel;
        //Func pour des methodes qui ont un type de retour, double c'est le type de retour, string c'est ce qu'il prend en parametre(on peux avoir plusieurs types de parametre)
        public Func<string, double> DurationAverageDel;
        public FlightMethods() {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            // expression lamda: (1) =>{(2)}: dans la partie 1 on met le nom des parametres exp(pl,i) et dans la partie 2 le comportement de la methode
            FlightDetailsDel= pl=> {
                var req = from f in Flights
                          where f.Plane == pl
                          select new { f.Destination, f.FlightDate };
                foreach (var f in req)
                    Console.WriteLine(f);
            };
            DurationAverageDel = destination => {
                var req = from f in Flights
                          where f.Destination == destination
                          select f.EstimatedDuration;
                return req.Average();
            };
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlight()
        {
            var req= from f in Flights
                     group f by f.Destination;
            //reecriture de la requete avec la lambda expression
            var req2 = Flights.GroupBy(f => f.Destination);
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

        //public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        //{
        //    var req = from t in flight.Passengers.OfType<Traveller>()
        //              orderby t.BirthDate
        //              select t;
        //    //recuperer les 3 premieres occurences
        //    return req.Take(3);
        //    //Skip (3) pour ignorer les 3 premieres occruences
        //              ;
        //}

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
