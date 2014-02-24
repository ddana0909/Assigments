using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TravelAgency.HelperClasses;


namespace TravelAgency.Models
{
    public class Leg
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the Start Location.")]
        public string StartLocation { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Numbers and special characters are not allowed in the Finish Location.")]
        public string FinishLocation { get; set; }


        [Required]
        [Remote("StartDateOutsideTrip", "Leg", HttpMethod = "POST", ErrorMessage = "Date falls outside the period of the trip ", AdditionalFields = "TripId")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]     
        public DateTime StartDate { get; set; }

        [Required]
        [Remote("FinishDateOutsideTrip", "Leg", HttpMethod = "POST", ErrorMessage = "Date falls outside the period of the trip ", AdditionalFields = "TripId")]         
        [GreaterThan("StartDate")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FinishDate { get; set;}
        
        [DisplayName("Trip")]
        public int TripId { get; set; }

        public virtual ICollection<LegRegistration> LegRegistrations { get; set; }
        public virtual Trip Trip { get; set; }

    }
}