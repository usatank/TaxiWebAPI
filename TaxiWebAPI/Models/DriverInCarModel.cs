using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiDataProvider.EntitiesLinq2Sql;
using Utils;

namespace TaxiWebAPI.Models
{
    public class DriverInCarModel : IDisposable
    {
        public DriverInCarModel()
        {

        }

        public DriverInCarModel(DriverInCar d)
        {
            if (!Assert.IsNull(d))
            {
                Id = d.Id;
                CarId = d.CarId;
                DriverId = d.DriverId;
                Location = d.Location;
                Address = d.Address;
                Car = new CarModel(d.Car);
                Driver = new DriverModel(d.Driver);
            }

        }

        public int Id { get; private set; }

        public int CarId { get; set; }

        public int DriverId { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public CarModel Car { get; set; }

        public DriverModel Driver { get; set; }

        public void Dispose()
        {
        }

    }
}