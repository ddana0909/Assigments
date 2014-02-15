using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models
{
    public class Leg
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string FinishLocation { get; set; }

        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FinishDate { get; set;}
        public int TripId { get; set; }

        public virtual ICollection <Guest> Guests { get; set; }
        public virtual Trip Trip { get; set; }

    }
}