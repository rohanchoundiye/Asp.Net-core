using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class FlightBookingDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FlightId { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }

        [Required]
        public string DateOfJourney { get; set; }
    }
}
