using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDataProvider.Entities;

namespace TaxiDataProvider
{
    public class AdoNetTaxiDataRepository : ITaxiDataRepository
    {
        public IQueryable<Car> GetAllCars()
        {
            IQueryable<Car> cars = null;
            return cars;
        }

        public Car GetCar(int id)
        {
            Car car = null;

            return car;
        }

        public IQueryable<Driver> GetAllDrivers()
        {
            IQueryable<Driver> drivers = null;

            return drivers;
        }

        public Driver GetDriver(int id)
        {
            Driver driver = null;

            return driver;
        }

        public IQueryable<Passenger> GetAllPassengers()
        {
            IQueryable<Passenger> passengers = null;

            return passengers;

        }

        public Passenger GetPassenger(int id)
        {
            Passenger passenger = null;

            return passenger;

        }

        public IQueryable<Order> GetAllOrders()
        {
            IQueryable<Order> orders = null;
            return orders;
        }

        public Order GetOrder(int id)
        {
            Order order = null;
            return order;
        }
    }
}
