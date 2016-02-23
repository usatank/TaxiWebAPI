using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDataProvider.Entities;
using System.Data.SqlClient;
using System.Configuration;
using Utils;

namespace TaxiDataProvider
{
    public class AdoNetTaxiDataRepository : ITaxiDataRepository
    {
        private readonly string _dataBaseName;
        private readonly string _connectionString;

        public AdoNetTaxiDataRepository()
        {
            _dataBaseName = "TaxiDatabase";
            _connectionString = String.Empty;
            try
            {
                _connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[_dataBaseName].ConnectionString;
            }
            catch (Exception exc)
            {
                Logger.Error(exc);
                
            }            
            
        }



        public IQueryable<Car> GetAllCars()
        {
            IQueryable<Car> cars = null;

            if (_connectionString == String.Empty)
            {
                
            }

            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {

            }
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
