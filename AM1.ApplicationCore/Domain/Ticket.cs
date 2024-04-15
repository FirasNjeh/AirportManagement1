using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Domain
{
    //Classe porteuse de données toujours en association 1-*/ 1-* avec les 2 classes
    public class Ticket
    {
        public double Prix { get; set; }
        public string Siege { get; set; }
        public Boolean VIP { get; set; }

        public virtual Passenger Passenger { get; set; }
        [ForeignKey("Passenger")]
        public string PassengerFK { get; set; }
        public virtual Flight Flight { get; set; }
        [ForeignKey("Flight")]
        public int FlightFK { get; set; }

    }
}
