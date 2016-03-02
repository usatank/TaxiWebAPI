using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiWebAPI.Models
{
    public class DriverInCarModel
    {
        public int Id { get; }

        public int CarId { get; set; }

        public int DriverId { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public CarModel Car { get; set; }

        public DriverModel Driver { get; set; }
    }
}