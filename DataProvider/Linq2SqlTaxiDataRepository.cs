using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDataProvider.EntitiesLinq2Sql;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Configuration;
using Utils;

namespace TaxiDataProvider
{
    public class Linq2SqlTaxiDataRepository : ITaxiDataRepository, IDisposable
    {
        private readonly string _dataBaseName;
        private readonly string _connectionString;

        public Linq2SqlTaxiDataRepository()
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

        public virtual bool AddCar(Car car)
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString) || Assert.IsNull(car))
                return false;

            using (TaxiDataBaseContext taxiDatabaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {              

                try
                {
                    taxiDatabaseContext.Cars.InsertOnSubmit(car);
                    taxiDatabaseContext.SubmitChanges();
                    return true;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return false;
                }

            }


        }

        public virtual List<Car> GetAllCars()
        {

            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString))
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

        public virtual Car GetCar(int id)
        {

            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString) || !Assert.IsPositive(id))
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

        public virtual List<Driver> GetAllDrivers()
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString))
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

        public virtual Driver GetDriver(int id)
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString) || !Assert.IsPositive(id))
                return null;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    Driver driver = taxiDataBaseContext.GetTable<Driver>().Where<Driver>(d => d.Id == id).First();
                    return driver;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;
                }
            }
        }

        public virtual bool AddDriver(Driver driver)
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString) || Assert.IsNull(driver))
                return false;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                taxiDataBaseContext.Drivers.InsertOnSubmit(driver);

                try
                {
                    taxiDataBaseContext.SubmitChanges();
                    return true;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return false;
                }

            }
        }

        public virtual bool AddPassenger(Passenger passenger)
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString) || Assert.IsNull(passenger))
                return false;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {               

                try
                {
                    taxiDataBaseContext.Passengers.InsertOnSubmit(passenger);
                    taxiDataBaseContext.SubmitChanges();
                    return true;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return false;
                }
            }
        }

        public virtual List<Passenger> GetAllPassengers()
        {            

            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    List<Passenger> passengers = taxiDataBaseContext.GetTable<Passenger>().ToList<Passenger>();
                    return passengers;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;
                }
            }
        }

        public virtual Passenger GetPassenger(int id)
        {          

            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString) || !Assert.IsPositive(id))
                return null;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    Passenger passenger = taxiDataBaseContext.GetTable<Passenger>().Where<Passenger>(p => p.Id == id).First<Passenger>();
                    return passenger;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;
                }
            }           

        }

        public virtual bool AddOrder(Order order)
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString) || Assert.IsNull(order))
                return false;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    taxiDataBaseContext.Orders.InsertOnSubmit(order);
                    taxiDataBaseContext.SubmitChanges();
                    return true;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return false;

                }
            }
        }

        public virtual List<Order> GetAllOrders()
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    List<Order> orders = taxiDataBaseContext.GetTable<Order>().ToList<Order>();
                    return orders;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;
                }
            }
         
        }

        public virtual Order GetOrder(int id)
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString) || !Assert.IsPositive(id))
                return null;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    Order order = taxiDataBaseContext.GetTable<Order>().Where<Order>(o => o.Id == id).First<Order>();
                    return order;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;
                }
            }

         
        }

        public virtual List<DriverInCar> GetAllDriversInCars()
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString))
                return null;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    List<DriverInCar> driversInCars = taxiDataBaseContext.GetTable<DriverInCar>().ToList<DriverInCar>();
                    return driversInCars;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;

                }
            }
        }

        public virtual DriverInCar GetDriverInCar(int id)
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString) || !Assert.IsPositive(id))
                return null;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    DriverInCar driverInCar = taxiDataBaseContext.GetTable<DriverInCar>().Where<DriverInCar>(d => d.Id == id).First<DriverInCar>();
                    return driverInCar;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return null;
                }
            }
        }

        public virtual bool AddDriverInCar(DriverInCar driverInCar)
        {
            if (Assert.IsNullOrEmtpyOrWhitespace(_connectionString) || Assert.IsNull(driverInCar))
                return false;

            using (TaxiDataBaseContext taxiDataBaseContext = new TaxiDataBaseContext(new SqlConnection(_connectionString)))
            {
                try
                {
                    taxiDataBaseContext.DriversInCars.InsertOnSubmit(driverInCar);
                    taxiDataBaseContext.SubmitChanges();
                    return true;
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                    return false;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
