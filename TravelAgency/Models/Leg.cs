using System;
using System.Collections.Generic;

namespace TravelAgency.Models
{
    public class Leg
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string FinishLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set;}

        public virtual ICollection <Guest> Guests { get; set; }
        public virtual Trip Trip { get; set; }

    }
}