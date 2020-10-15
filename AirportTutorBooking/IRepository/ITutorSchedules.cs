using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.IRepository
{
    public interface ITutorSchedules
    {
        Task<IEnumerable<TutorSchedulesModel>> GetAllList();
        Task<IEnumerable<TutorSchedulesModel>> CreateRecord(TutorSchedulesModel request);
        Task<IEnumerable<TutorSchedulesModel>> UpdateRecord(TutorSchedulesModel request);
        Task<IEnumerable<TutorSchedulesModel>> DeleteRecord(TutorSchedulesModel request);
    }
}
