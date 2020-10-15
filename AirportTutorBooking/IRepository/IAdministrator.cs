using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.IRepository
{
    public interface IAdministrator
    {
        Task<List<AdministratorsModel>> GetAllList();
        Task<AdministratorsModel> CreateRecord(AdministratorsModel request);
        Task<AdministratorsModel> Login(AdministratorsModel request);
        Task<AdministratorsModel> UpdateRecord(AdministratorsModel request);
        Task<AdministratorsModel> DeleteRecord(AdministratorsModel request);
    }
}
