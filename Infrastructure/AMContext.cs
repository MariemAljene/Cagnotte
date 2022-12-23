
using AM.ApplicationCore.Interfaces;
using ApplicationCore.Domain;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace AM.Infrastructure
{
    public class AMContext: DbContext
    {

        public DbSet<Cagnotte> Cagnottes { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<Entreprise> Entreprise { get; set; }



        //public DbSet<Flight> Flights { get; set; }
        //public DbSet<Passenger> Passengers { get; set; }
        //public DbSet<Staff> Staff { get; set; }
        //public DbSet<Traveller> Travellers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=CagnotteDB;Integrated Security=true;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParticipationConfiguration());
            //modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            //modelBuilder.ApplyConfiguration(new TicketConfiguration());

            //modelBuilder.Entity<Staff>().ToTable("Staff");
            //modelBuilder.Entity<Traveller>().ToTable("Travellers");

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //    // Pre-convention model configuration goes here
            //    configurationBuilder
            //        .Properties<string>()
            //        .HaveMaxLength(50);
            //configurationBuilder
            //    .Properties<decimal>()
            //        .HavePrecision(8,3);
            configurationBuilder
              .Properties<MailAddress>();
              //  .HaveAnnotation(RequiredAttribute);
        }



    }
}
