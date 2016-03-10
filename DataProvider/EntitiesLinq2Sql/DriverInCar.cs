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

        public Driver Driver { get; set; }

        public Car Car { get; set; }
               
        public DriverInCar()
        {
           
        }

        public DriverInCar(int dICId)
        {
            Id = dICId;
        }

        public bool Equals(DriverInCar driverInCar2)
        {
            if (driverInCar2 == null)
                return false;

            bool driverEquals = false;
            if (this.Driver == null && driverInCar2.Driver == null)
                driverEquals = true;
            else
            {
                if (this.Driver != null)
                    driverEquals = this.Driver.Equals(driverInCar2.Driver);
            }

            bool carEquals = false;
            if (this.Car == null && driverInCar2.Driver == null)
                carEquals = true;
            else
            {
                if (this.Car != null)
                    carEquals = this.Car.Equals(driverInCar2.Car);
            }

            return (this.Id == driverInCar2.Id &&
                    this.CarId == driverInCar2.CarId &&
                    this.DriverId == driverInCar2.DriverId &&
                    this.Address == driverInCar2.Address &&
                    this.Location == driverInCar2.Location && 
                    driverEquals &&
                    carEquals);
        }

        public void Dispose()
        {
            //for testing purposes
        }
    }
}
