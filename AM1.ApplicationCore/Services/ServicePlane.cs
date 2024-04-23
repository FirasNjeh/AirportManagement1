using AM1.ApplicationCore.Domain;
using AM1.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {


        }

        public void DeletePlanes()
        {
            Delete(p=>(DateTime.Now-p.ManufactureDate).TotalDays>3650);
        }

        public IEnumerable<Flight> GetFlights(int n)
        {
           return GetMany().OrderByDescending(p=>p.PlaneId)
                     .Take(n)
                     .SelectMany(p=>p.Flights)
                     .OrderBy(f=>f.FlightDate);
            
        }

        public IEnumerable<Traveller> GetPassengers(Plane p)
        {
            //Select on recupere 1 seul valeur
            //SelectMany chaque obj de la collection va me renvoyer à une autre collection
            return p.Flights.SelectMany(f => f.Tickets)
                            .Select(t => t.Passenger)
                            .OfType<Traveller>();
        }

        public bool IsAvailablePlane(Flight f, int n)
        {
            return f.Plane.Capacity>=f.Tickets.Count+n;
                

        }
    }

}
