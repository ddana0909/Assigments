using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TravelAgency.Models
{
    public class AddTripModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FinishDate { get; set; }
        [DisplayName("Minumum Number of Guests")]
        public int MinimumGuests { get; set; }

        public HttpPostedFileBase PromoPicture { get; set; }
    }
}