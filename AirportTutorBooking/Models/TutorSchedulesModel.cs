using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTutorBooking.Models
{
    public class TutorSchedulesModel
    {
        public int Id { get; set; }
        public int TutorId { get; set; }
        public int PlaneId { get; set; }
        public int AirportId { get; set; }
        public DateTime AvailableDate { get; set; }
        public bool isAvailable { get; set; }

        public TutorsModel Tutor { get; set; }
    }
}
