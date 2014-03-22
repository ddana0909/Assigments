using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TravelAgency.Models
{
    public class GuestRegistration
    {
        public int GuestRegistrationId { get; set; }
        public int LegId { get; set; }
        [Required]
        [Remote("IsAlreadyRegistered","GuestRegistration",HttpMethod = "POST", ErrorMessage = "This Guest is already registred on this leg!", AdditionalFields = "LegId")]
        public int GuestId { get; set;}

        public virtual Leg Leg { get; set; }
        public virtual Guest Guest { get; set; }
    
    }
}
