namespace TravelAgency.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public virtual Leg Leg { get; set; }
    }
}