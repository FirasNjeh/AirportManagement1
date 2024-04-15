using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key]
        [StringLength(7)]//=>uniquement sur un string
        public string PassportNumber { get; set; }

        public FullName FullName { get; set; }

        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        [RegularExpression("@[1-9]{8}")] // longueur 8 uniquement des chiffres
        public string TelNumber { get; set; }

        [DataType(DataType.EmailAddress,ErrorMessage ="Email invalide")]
        public string EmailAddress { get; set; }

        //public ICollection<Flight> Flights { get; set; }
        //Lors de l'ajout de la table porteuse de donnée on ne doit pas mettre les relations directes 
        public virtual ICollection<Ticket> Tickets { get; set; }
        //public Boolean CheckProfile(string FirstName,string LastName)
        //{
        //    return (this.FirstName.Equals(FirstName) && this.LastName.Equals(LastName));      
        //}
        public Boolean CheckProfile(string FirstName, string LastName, string email=null)
        {
            if(email == null) 
            return (this.FullName.FirstName.Equals(FirstName) && this.FullName.LastName.Equals(LastName));
            else
                return (this.FullName.FirstName.Equals(FirstName) && this.FullName.LastName.Equals(LastName) && EmailAddress.Equals(email));


        }
        //Virtual = redefinissable dans la classe fille
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }



    }
}
