using AM1.ApplicationCore.Domain;
using AM1.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Services
{
    public class ServicePassenger : Service<Passenger>, IServicePassenger
    {
        public ServicePassenger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
