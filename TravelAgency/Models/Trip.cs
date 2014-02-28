using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TravelAgency.HelperClasses;

namespace TravelAgency.Models
{
    public class Trip
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "A name is required for tge trip")]
        public string Name { get; set; }
        
        [DataRange]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [GreaterThan("StartDate")]
        public DateTime FinishDate { get; set; }
        
        [Range(3,60,ErrorMessage = "{0} has to be a number between {1} and {2}")]
        [DisplayName("Minumum Number of Guests")]
        public int MinimumGuests { get; set; }
        
        public bool Viable { get; set; }
        public bool Complete { get; set; }
        public string PicturePath { get; set; }

        public virtual ICollection<Leg> Legs { get; set; }
    }
}