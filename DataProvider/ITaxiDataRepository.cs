using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDataProvider.Entities;

namespace TaxiDataProvider
{
    public interface ITaxiDataRepository
    {
        IQueryable<Car> GetAllCars();

        Car GetCar(int id);
                
        IQueryable<Driver> GetAllDrivers();

        Driver GetDriver(int id);

        IQueryable<Passenger> GetAllPassengers();

        Passenger GetPassenger(int id);

        IQueryable<Order> GetAllOrders();

        Order GetOrder(int id);        

    }
}
