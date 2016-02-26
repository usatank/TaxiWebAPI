using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxiDataProvider;
using TaxiDataProvider.EntitiesLinq2Sql;
using System.Data.Linq;

namespace TaxiWebAPI
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Linq2SqlTaxiDataRepository repo = new Linq2SqlTaxiDataRepository();
            //repo.AddCar(new Car { Brand = "Kia", Model = "Cerato", Number = "AA0802AH" });
            
            var cars = repo.GetAllCars();
            foreach (Car car in cars)
            {
                Response.Write("Car: " + car.Id + " " + car.Brand + " " + car.Model + " " + car.Number + "<br />");
            }

            int id = 1;
            var car1 = repo.GetCar(id);

            Response.Write("Car with id " + id.ToString() + ": " + car1.Brand + " " + car1.Model + " " + car1.Number + "<br />");
            id = 2;
            var car2 = repo.GetCar(id);
            Response.Write("Car with id " + id.ToString() + ": " + car2.Brand + " " + car2.Model + " " + car2.Number + "<br />");

            //repo.AddDriver(new Driver { FirstName = "Ivan", LastName = "Petrov", HomeAddress = "Kiev, str. Vasylkivs'ka", PhoneNumber = "0990004455" });

            var drivers = repo.GetAllDrivers();
            foreach (var driver in drivers)
            {
                Response.Write("Driver: " + driver.Id + " " + driver.FirstName + " " + driver.LastName + " " + driver.HomeAddress + " " + driver.PhoneNumber + "<br />");

            }

            id = 1;

            var driver1 = repo.GetDriver(id);
            Response.Write("Driver with id " + id.ToString() + ": " + driver1.FirstName + " " + driver1.LastName + " " + driver1.HomeAddress + " " + driver1.PhoneNumber + "<br />");

            id = 2;

            var driver2 = repo.GetDriver(id);
            Response.Write("Driver with id " + id.ToString() + ": " + driver2.FirstName + " " + driver2.LastName + " " + driver2.HomeAddress + " " + driver2.PhoneNumber + "<br />");

            //repo.AddPassenger(new Passenger { Name = "Sergii", PhoneNumber = "0978668544"});

            var passengers = repo.GetAllPassengers();

            foreach (var passenger in passengers)
            {
                Response.Write("Passenger: " + passenger.Id + " " + passenger.Name + " " + passenger.PhoneNumber + "<br />");
            }

            id = 1;
            var passenger1 = repo.GetPassenger(id);

            Response.Write("Passenger with id " + id + ": " + passenger1.Name + " " + passenger1.PhoneNumber + "<br />");
            id = 2;
            var passenger2 = repo.GetPassenger(id);
            Response.Write("Passenger with id " + id + ": " + passenger2.Name + " " + passenger2.PhoneNumber + "<br />");

            //repo.AddOrder(new Order {Address = "Lugova 12", DateAndTime = DateTime.Now.AddHours(3.0), Location = "50.505041, 30.471715", PassengerId = passenger2.Id});

            var orders = repo.GetAllOrders();
            foreach (var order in orders)
            {
                Response.Write("Order: " + order.Id + " " + order.Address + " " + order.DateAndTime.ToString() + " " + order.Location + " " + order.PassengerId + "<br />");
            }

            id = 1;
            var order1 = repo.GetOrder(id);
            Response.Write("Order with id " + id.ToString() + ": " + order1.Address + " " + order1.DateAndTime.ToString() + " " + order1.Location + " " + order1.PassengerId + "<br />");

            id = 2;
            var order2 = repo.GetOrder(id);
            Response.Write("Order with id " + id.ToString() + ": " + order2.Address + " " + order2.DateAndTime.ToString() + " " + order2.Location + " " + order2.PassengerId + "<br />");

            //repo.AddDriverInCar(new DriverInCar { Address = "Peremogy, 50", CarId = 2, DriverId = 1, Location = "50.456651, 30.444473" });

            var driversInCars = repo.GetAllDriversInCars();

            foreach (var driverInCar in driversInCars)
            {
                Response.Write("Driver in car: " + driverInCar.Id + " " + driverInCar.Address + " " + driverInCar.CarId + " " + driverInCar.Location + " " + driverInCar.DriverId + "<br />");

            }

            id = 1;
            var driverInCar1 = repo.GetDriverInCar(id);
            Response.Write("Driver in car with id " + id + ": " + driverInCar1.Address + " " + driverInCar1.CarId + " " + driverInCar1.Location + " " + driverInCar1.DriverId + "<br />");

            id = 2;
            var driverInCar2 = repo.GetDriverInCar(id);
            Response.Write("Driver in car with id " + id + ": " + driverInCar2.Address + " " + driverInCar2.CarId + " " + driverInCar2.Location + " " + driverInCar2.DriverId + "<br />");

        }
    }
}