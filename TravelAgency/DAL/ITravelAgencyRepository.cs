using System;
using System.Linq;
using TravelAgency.Models;

namespace TravelAgency.DAL
{
    interface ITravelAgencyRepository :IDisposable
    {
        IQueryable <Trip> GetAllTrips();
    }

}
