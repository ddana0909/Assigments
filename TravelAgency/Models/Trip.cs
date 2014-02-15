using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace TravelAgency.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FinishDate { get; set; }
        public int MinimumGuests { get; set; }
        public bool Viable { get; set; }

        public virtual ICollection<Leg> Legs { get; set; }
    }
}