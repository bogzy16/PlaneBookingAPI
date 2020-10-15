using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTutorBooking.Models
{
    public class AirportsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }

        public IList<PlanesModel> AirportPlanes { get; set; }
        public IList<TutorsModel> AirportTutors { get; set; }
        public IList<MaintenanceSchedulesModel> AirportMaintenanceSchedules { get; set; }
    }
}
