using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.IRepository
{
    public interface IAirports
    {
        Task<List<AirportsModel>> GetAllList();
        Task<AirportsModel> CreateRecord(AirportsModel request);
        Task<AirportsModel> UpdateRecord(AirportsModel request);
        Task<AirportsModel> DeleteRecord(AirportsModel request);
        Task<List<AirportsModel>> GetAirportPlanes(AirportsModel request);
    }
}
    