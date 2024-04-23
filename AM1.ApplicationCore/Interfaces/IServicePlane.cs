using AM1.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Interfaces
{
    public interface IServicePlane:IService<Plane>
    {
        IEnumerable<Traveller> GetPassengers(Plane p);
        IEnumerable<Flight> GetFlights(int n);
        Boolean IsAvailablePlane(Flight f,int n);
        void DeletePlanes();


    }
}
    