using AM1.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Services
{
    // La classe d'extension doit toujours etre statique
    public static class PassengerExtension
    {
        //Les methodes de la classe d'extension doivent etre statique aussi
        //Ajouter avant le parametre de la classe a etendre (ici comme exemple Passenger) le mot clé this
        public static void UpperFullName(this Passenger p)
        {
            p.FirstName = p.FirstName[0].ToString().ToUpper()+p.FirstName.Substring(1);
            p.LastName = p.LastName[0].ToString().ToUpper() + p.LastName.Substring(1);

        }
    }
}
