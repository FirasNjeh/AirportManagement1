using AM.Infrastructure.Configurations;
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
        //Classe porteuse de donnée entre Passenger et Flight
        public DbSet<Ticket> Tickets { get; set; }

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
            //Autoriser la jointure( EXP :passer de la type flight à la table plane) +tous les objets de navigations doivent etre virtual
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            //2eme methode de configuration au lieu de creer une classe on realise directement les configurations dans AMCONTEXT 
            modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("Myplanes");
            modelBuilder.Entity<Plane>().Property(p => p.Capacity).HasColumnName("PlaneCapacity");

            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //Configurer le type detenu(Owned Type)
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName);
            //Configurer l'heritage Table par Hierarchy (TPH)
            //modelBuilder.Entity<Passenger>().HasDiscriminator<int>("IsTraveller")
            //    .HasValue<Passenger>(0)
            //    .HasValue<Traveller>(1)
            //    .HasValue<Staff>(2);
            //Configurer l'heritage Table par Type (TPT)
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
            //Configurer la clé primaire de la porteuse de donnée
            modelBuilder.Entity<Ticket>().HasKey(t=>new {t.FlightFK,t.PassengerFK});


            base.OnModelCreating(modelBuilder);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            base.ConfigureConventions(configurationBuilder);
        }



    }
}
