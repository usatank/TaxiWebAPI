using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDataProvider.EntitiesAdoNet;
using System.Data.SqlClient;
using System.Data.Linq;
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

        public bool AddCar(Car car)
        {
            if (StringUtil.NullOrEmtpyOrWhitespace(_connectionString))
                return false;

            using (TaxiDataBaseContext taxiDatabaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                taxiDatabaseContext.Cars.InsertOnSubmit(car);

                bool result = false;

                try
                {
                    taxiDatabaseContext.SubmitChanges();
                    result = true;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    result = false;
                }               

                return result;

            }

            
        }

        public List<Car> GetAllCars()
        {

            if (StringUtil.NullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (TaxiDataBaseContext taxiDatabaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    var cars = taxiDatabaseContext.GetTable<Car>().ToList<Car>();
                    return cars;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;
                }
                

            }   

        }

        public Car GetCar(int id)
        {        

            if (StringUtil.NullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (TaxiDataBaseContext taxiDatabaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    Car car = taxiDatabaseContext.GetTable<Car>().Where<Car>(c => c.Id == id).First();
                    return car;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;
                }

            }

         
        }

        public List<Driver> GetAllDrivers()
        {
            if (StringUtil.NullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    var drivers = taxiDataBaseContext.GetTable<Driver>().ToList<Driver>();
                    return drivers;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;
                }
                
            }
                
        }

        public Driver GetDriver(int id)
        {
            if (StringUtil.NullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (TaxiDataBaseContext dataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    Driver driver = dataBaseContext.GetTable<Driver>().Where<Driver>(d => d.Id == id).First();
                    return driver;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;
                }
            }
        }

        public List<Passenger> GetAllPassengers()
        {
            List<Passenger> passengers = null;

            if (StringUtil.NullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {

            }

            return passengers;

        }

        public Passenger GetPassenger(int id)
        {
            Passenger passenger = null;

            if (StringUtil.NullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {

            }

            return passenger;

        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = null;

            if (StringUtil.NullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {

            }

            return orders;
        }

        public Order GetOrder(int id)
        {
            Order order = null;

            if (StringUtil.NullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {

            }

            return order;
        }
    }
}
