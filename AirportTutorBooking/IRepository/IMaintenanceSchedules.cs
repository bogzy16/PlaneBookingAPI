using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.IRepository
{
    public interface IMaintenanceSchedules
    {
        Task<IEnumerable<MaintenanceSchedulesModel>> GetAllList();
        Task<IEnumerable<MaintenanceSchedulesModel>> CreateRecord(MaintenanceSchedulesModel request);
        Task<IEnumerable<MaintenanceSchedulesModel>> UpdateRecord(MaintenanceSchedulesModel request);
        Task<IEnumerable<MaintenanceSchedulesModel>> DeleteRecord(MaintenanceSchedulesModel request);
    }
}
