﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DisplayName("Minumum Number of Guests")]
        public int MinimumGuests { get; set; }
        public bool Viable { get; set; }
        public bool Complete { get; set; }
        public string PicturePath { get; set; }

        public virtual ICollection<Leg> Legs { get; set; }
    }
}