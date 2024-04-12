using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Domain
{
    public class Passenger
    {
        
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TelNumber { get; set; }
        public int Id { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<Flight> Flights { get; set; }

        //public Boolean CheckProfile(string FirstName,string LastName)
        //{
        //    return (this.FirstName.Equals(FirstName) && this.LastName.Equals(LastName));      
        //}
        public Boolean CheckProfile(string FirstName, string LastName, string email=null)
        {
            if(email == null) 
            return (this.FirstName.Equals(FirstName) && this.LastName.Equals(LastName));
            else
                return (this.FirstName.Equals(FirstName) && this.LastName.Equals(LastName) && EmailAddress.Equals(email));


        }
        //Virtual = redefinissable dans la classe fille
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }



    }
}
