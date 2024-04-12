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

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            IEnumerable < DateTime > dateTimes = new List<DateTime>();
            //Parcours la liste des flight dans la liste flights comme for 
            //foreach (Flight f in Flights)
            //{
            //    if (f.Destination == destination)
            //    {
            //        dateTimes.Add(f.FlightDate);
            //        Console.WriteLine(f.FlightDate);
            //    }
            //}
            dateTimes=from f in Flights
                      where f.Destination == destination
                      select f.FlightDate;
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
    }
}
