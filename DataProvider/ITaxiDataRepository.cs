using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDataProvider.EntitiesAdoNet;

namespace TaxiDataProvider
{
    public interface ITaxiDataRepository
    {
        List<Car> GetAllCars();

        Car GetCar(int id);
                
        List<Driver> GetAllDrivers();

        Driver GetDriver(int id);

        List<Passenger> GetAllPassengers();

        Passenger GetPassenger(int id);

        List<Order> GetAllOrders();

        Order GetOrder(int id);        

    }
}
