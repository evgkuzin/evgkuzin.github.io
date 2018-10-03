namespace Airport.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            PassengerFlights = new HashSet<PassengerFlight>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FlightCode { get; set; }

        public Guid AirportDepartureId { get; set; }

        public Guid AirportArrivalId { get; set; }

        [StringLength(50)]
        public string TimeDeparture { get; set; }

        [StringLength(50)]
        public string TimeArrival { get; set; }

        [StringLength(50)]
        public string AircraftType { get; set; }

        public string AdditionalInformation { get; set; }

        public virtual Airport Airport { get; set; }
        
        //public virtual Airport AirportDeparture
        //{
        //    get
        //    {
        //        DBContext db = new DBContext();
        //        return db.Airports.Find(AirportDepartureId);
        //    }
        //    set
        //    {
        //        this.AirportDeparture = value;
        //    }
        //}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PassengerFlight> PassengerFlights { get; set; }
    }
}
