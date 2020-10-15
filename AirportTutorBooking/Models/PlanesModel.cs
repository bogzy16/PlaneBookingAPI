using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTutorBooking.Models
{
    public class PlanesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }

        public AirportsModel Airports { get; set; }
    }
}
