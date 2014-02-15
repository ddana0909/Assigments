using System.Collections.Generic;

namespace TravelAgency.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<LegRegistration> LegRegistrations { get; set; }
    }
}