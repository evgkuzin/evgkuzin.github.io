namespace Airport.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PassengerFlight")]
    public partial class PassengerFlight
    {
        public Guid Id { get; set; }

        public Guid PassengerId { get; set; }

        public Guid FlightId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateDeparture { get; set; }

        public Guid? BaggageCode { get; set; }

        public string AdditionalInformation { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual Passenger Passenger { get; set; }
    }
}
