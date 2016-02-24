using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using TaxiDataProvider.EntitiesAdoNet;

namespace TaxiDataProvider
{
    public partial class TaxiDataBaseContext : DataContext
    {
        public TaxiDataBaseContext(IDbConnection connection) : base (connection)
        {
        }

        public Table<Car> Cars;

        public Table<Driver> Drivers;

        public Table<Order> Orders;

        public Table<DriverInCar> DriversInCars;

        public Table<Passenger> Passengers;
    }
}
