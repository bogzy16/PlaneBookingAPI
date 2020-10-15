using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTutorBooking.Models
{
    public class MaintenanceSchedulesModel
    {
        public int Id { get; set; }
        public int AirportId { get; set; }
        public string Name { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool isActive { get; set; }

        public AirportsModel Airports { get; set; }
    }
}
