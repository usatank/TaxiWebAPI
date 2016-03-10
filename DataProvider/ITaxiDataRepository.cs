using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDataProvider.EntitiesLinq2Sql;

namespace TaxiDataProvider
{
    public interface ITaxiDataRepository : IDisposable
    {
        List<Car> GetAllCars();

        Car GetCar(int id);

        bool AddCar(Car car);
                
        List<Driver> GetAllDrivers();

        Driver GetDriver(int id);

        bool AddDriver(Driver driver);

        List<Passenger> GetAllPassengers();

        Passenger GetPassenger(int id);

        bool AddPassenger(Passenger passenger);

        List<Order> GetAllOrders();

        Order GetOrder(int id);

        bool AddOrder(Order order);

        List<DriverInCar> GetAllDriversInCars();

        DriverInCar GetDriverInCar(int id);

        bool AddDriverInCar(DriverInCar driverInCar);
        

    }
}
