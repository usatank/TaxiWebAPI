using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace TaxiDataProvider.EntitiesLinq2Sql
{
    [Table(Name = "DriversInCars")]
    public class DriverInCar : IDisposable
    {
        private int _id;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Id", Storage = "_id")]
        public int Id
        {
            get { return this._id; }
            private set { this._id = value; }
        }

        private int _carId;

        [Column(Name = "CarId", Storage = "_carId")]
        public int CarId
        {
            get { return this._carId; }
            set { this._carId = value; }
        }

        private int _driverId;

        [Column(Name = "DriverId", Storage = "_driverId")]
        public int DriverId
        {
            get { return this._driverId; }
            set { this._driverId = value; }
        }

        private string _address;
        [Column(Name = "Address", Storage = "_address")]
        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        private string _location;

        [Column(Name = "Location", Storage = "_location")]
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }

        //for testing purposes
        public DriverInCar()
        {
            Id = 1;
        }

        public void Dispose()
        {
            //for testing purposes
        }
    }
}
