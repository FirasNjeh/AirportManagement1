using AM1.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext :DbContext
    {
        //DBSets
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Traveller> Travellers{ get; set; }

        //Chaine de connexion (faire la connexion avec la BD) chaque serveur de BD a sa propre methode 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                //data source : instance sous laquelle on va creer notter bd
                //Initial catalog: nom de la base de données
                //Integrated security: utilisation des parametres d'authentification de windows par defaut
                //MultipleActiveResultSets: Realisation de jointure
                (@"Data Source=(localdb)\mssqllocaldb;
                Initial Catalog=AirportManagementDB;
                Integrated Security=true;
                MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }



    }
}
