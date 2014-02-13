using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class LegRegistration
    {
        public int LegRegistrationId { get; set; }
        public int LegId { get; set; }
        public int GuestId { get; set;}

        public virtual Leg Leg { get; set; }
        public virtual Guest Guest { get; set; }
    
    }
}