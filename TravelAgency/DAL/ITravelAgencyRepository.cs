using System;
using System.Linq;
using TravelAgency.Models;

namespace TravelAgency.DAL
{
    public interface ITravelAgencyRepository :IDisposable
    {
        IQueryable <Trip> GetAllTrips();
    }

}
