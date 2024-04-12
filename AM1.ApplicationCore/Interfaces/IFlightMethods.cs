﻿using AM1.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
      IEnumerable<DateTime>  GetFlightDates(string destination);
        void GetFlights(string filterType, string filterValue);
    }

}
