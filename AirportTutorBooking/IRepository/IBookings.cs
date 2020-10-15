using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportTutorBooking.Models;

namespace AirportTutorBooking.IRepository
{
    public interface IBookings
    {
        Task<IEnumerable<BookingsModel>> GetAllList();
        Task<IEnumerable<BookingsModel>> CreateRecord(BookingsModel request);
        Task<IEnumerable<BookingsModel>> UpdateRecord(BookingsModel request);
        Task<IEnumerable<BookingsModel>> DeleteRecord(BookingsModel request);
    }
}
