using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTutorBooking.Models
{
    public class TutorsModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }

        public AirportsModel Airports { get; set; }
        public List<TutorSchedulesModel>  Schedules { get; set; }

    }
}
