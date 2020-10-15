using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.IRepository
{
    public interface ITutors
    {
        Task<List<TutorsModel>> GetAllList();
        Task<TutorsModel> CreateRecord(TutorsModel request);
        Task<TutorsModel> Login(TutorsModel request);
        Task<TutorsModel> UpdateRecord(TutorsModel request);
        Task<TutorsModel> DeleteRecord(TutorsModel request);
    }
}
