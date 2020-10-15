using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.IRepository
{
    public interface IPlanes
    {
        Task<List<PlanesModel>> GetAllList();
        Task<PlanesModel> CreateRecord(PlanesModel request);
        Task<PlanesModel> UpdateRecord(PlanesModel request);
        Task<PlanesModel> DeleteRecord(PlanesModel request);
    }
}
