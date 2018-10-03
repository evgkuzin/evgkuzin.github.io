namespace Airport.WebUI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<PassengerFlight> PassengerFlights { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Airport>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Airport>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Flights)
                .WithRequired(e => e.Airport)
                .HasForeignKey(e => e.AirportArrivalId);

            modelBuilder.Entity<Country>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.FlightCode)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.TimeDeparture)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.TimeArrival)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.AircraftType)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.AdditionalInformation)
                .IsUnicode(false);

            modelBuilder.Entity<PassengerFlight>()
                .Property(e => e.AdditionalInformation)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Passenger>()
                .Property(e => e.Passport)
                .IsUnicode(false);
        }
    }
}
