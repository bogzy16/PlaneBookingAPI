using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportTutorBooking.Models;
namespace AirportTutorBooking.IRepository
{
    public interface IStudents
    {
        Task<List<StudentsModel>> GetAllList();
        Task<StudentsModel> CreateRecord(StudentsModel request);
        Task<StudentsModel> Login(StudentsModel request);
        Task<StudentsModel> UpdateRecord(StudentsModel request);
        Task<StudentsModel> DeleteRecord(StudentsModel request);
    }
}
