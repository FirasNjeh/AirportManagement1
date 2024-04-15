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
            p.FullName.FirstName = p.FullName.FirstName[0].ToString().ToUpper()+p.FullName.FirstName.Substring(1);
            p.FullName.LastName = p.FullName.LastName[0].ToString().ToUpper() + p.FullName.LastName.Substring(1);

        }
    }
}
