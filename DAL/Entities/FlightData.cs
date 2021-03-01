using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class FlightData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlightId { get; set; }
        public string FlightAmount { get; set; }
        public string SourceLocation { get; set; }
        public string DestinationLocation { get; set; }
        public string AvailableTickets { get; set; }
        [Required]
        public string FlightDate { get; set; }
        public string Status { get; set; }

    }
}
