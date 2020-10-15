using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTutorBooking.Models
{
    public class BookingsModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime BookedDate { get; set; }
        
        public IList<TutorSchedulesModel> BookingTutorSchedules { get; set; }
    }
}
