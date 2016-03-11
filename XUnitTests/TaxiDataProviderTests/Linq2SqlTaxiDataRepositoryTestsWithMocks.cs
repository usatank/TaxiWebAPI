using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Rhino.Mocks;
using TaxiDataProvider;
using TaxiDataProvider.EntitiesLinq2Sql;


namespace XUnitTests.TaxiDataProviderTests
{
    [Trait("Category", "Linq2SqlTaxiDataRepository Tests With Mocks")]
    public class Linq2SqlTaxiDataRepositoryTestsWithMocks
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldAddCar(bool expected)
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();
            Car car = new Car() { Brand = "Volkswagen", Model = "Polo Sedan", Number = "AI1234AT" };            
            Expect.Call(sut.AddCar(car)).Return(expected);
            repo.ReplayAll();
            Assert.Equal(expected, sut.AddCar(car));
            repo.VerifyAll();

        }

        [Fact]
        public void GetCarShouldReturnCar()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();
            int id = 1;
            Car carExpected = new Car(id);
            carExpected.Brand = "Volkswagen";
            carExpected.Model = "Polo Sedan";
            carExpected.Number = "AI1234AT";

            Expect.Call(sut.GetCar(id)).Return(carExpected);
            repo.ReplayAll();
            Assert.True(carExpected.Equals(sut.GetCar(id)));
            repo.VerifyAll();

        }

        [Fact]
        public void GetCarShouldReturnNull()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();
            int id = 10;
            Car carExpected = null;

            Expect.Call(sut.GetCar(id)).Return(carExpected);
            repo.ReplayAll();
            Assert.Null(sut.GetCar(id));
            repo.VerifyAll();

        }

        [Fact]
        public void GetAllCarsShouldReturnCollection()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            Car car = new Car(id);
            car.Brand = "Volkswagen";
            car.Model = "Polo Sedan";
            car.Number = "AI1234AT";
            List<Car> cars = new List<Car>();
            cars.Add(car);
            int timesToCall = 3;

            Expect.Call(sut.GetAllCars()).Return(cars).Repeat.Times(timesToCall);

            repo.ReplayAll();
            Assert.NotNull(sut.GetAllCars());
            Assert.NotEmpty(sut.GetAllCars());
            Assert.IsType<List<Car>>(sut.GetAllCars());

            repo.VerifyAll();

        }

        [Fact]
        public void GetAllCarsShouldReturnNull()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            List<Car> cars = null;

            Expect.Call(sut.GetAllCars()).Return(cars);

            repo.ReplayAll();
            Assert.Null(sut.GetAllCars());
            repo.VerifyAll();

        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldAddDriver(bool expected)
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            Driver driver = new Driver(id);
            driver.FirstName = "Oleksandr";
            driver.LastName = "Sidorov";
            driver.HomeAddress = "Peremogy, 50";
            driver.PhoneNumber = "0507854312";

            Expect.Call(sut.AddDriver(driver)).Return(expected);
            repo.ReplayAll();
            Assert.Equal(expected, sut.AddDriver(driver));
            repo.VerifyAll();
            
        }

        [Fact]
        public void GetAllDriversShouldReturnCollection()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            Driver driver = new Driver(id);
            driver.FirstName = "Oleksandr";
            driver.LastName = "Sidorov";
            driver.HomeAddress = "Peremogy, 50";
            driver.PhoneNumber = "0507854312";

            List<Driver> drivers = new List<Driver>();
            drivers.Add(driver);

            //todo
            int timesToCall = 3;
            Expect.Call(sut.GetAllDrivers()).Return(drivers).Repeat.Times(timesToCall);
            repo.ReplayAll();
            Assert.NotNull(sut.GetAllDrivers());
            Assert.NotEmpty(sut.GetAllDrivers());
            Assert.IsType<List<Driver>>(sut.GetAllDrivers());

            repo.VerifyAll();
        }

        [Fact]
        public void GetAllDriversShouldReturnNull()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            List<Driver> drivers = null;

            Expect.Call(sut.GetAllDrivers()).Return(drivers);
            repo.ReplayAll();
            Assert.Null(sut.GetAllDrivers());
            repo.VerifyAll();
        }

        [Fact]
        public void GetDriverShouldReturnDriver()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            Driver driver = new Driver(id);
            driver.FirstName = "Oleksandr";
            driver.LastName = "Sidorov";
            driver.HomeAddress = "Peremogy, 50";
            driver.PhoneNumber = "0507854312";

            Expect.Call(sut.GetDriver(id)).Return(driver);
            repo.ReplayAll();
            Assert.True(driver.Equals(sut.GetDriver(id)));
            repo.VerifyAll();

        }

        [Fact]
        public void GetDriverShouldReturnNull()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 10;
            Driver driver = null;

            Expect.Call(sut.GetDriver(id)).Return(driver);
            repo.ReplayAll();

            Assert.Null(sut.GetDriver(id));
            repo.VerifyAll();

        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldAddPassenger(bool expected)
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            Passenger pass = new Passenger(id);
            pass.Name = "Oleg";
            pass.PhoneNumber = "0663575855";

            Expect.Call(sut.AddPassenger(pass)).Return(expected);
            repo.ReplayAll();
            Assert.Equal(expected, sut.AddPassenger(pass));

            repo.VerifyAll();

        }

        [Fact]
        public void GetAllPassengersShouldReturnCollection()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            Passenger pass = new Passenger(id);
            pass.Name = "Oleg";
            pass.PhoneNumber = "0663575855";

            List<Passenger> passengers = new List<Passenger>();
            passengers.Add(pass);

            Expect.Call(sut.GetAllPassengers()).Return(passengers).Repeat.Times(3);
            repo.ReplayAll();
            Assert.NotNull(sut.GetAllPassengers());
            Assert.NotEmpty(sut.GetAllPassengers());
            Assert.IsType<List<Passenger>>(sut.GetAllPassengers());
            repo.VerifyAll();

        }

        [Fact]
        public void GetAllPassengersShouldReturnNull()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            List<Passenger> passengers = null;

            Expect.Call(sut.GetAllPassengers()).Return(passengers);
            repo.ReplayAll();
            Assert.Null(sut.GetAllPassengers());
            repo.VerifyAll();
        }

        [Fact]
        public void GetPassengerShouldReturnPassenger()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            Passenger pass = new Passenger(id);
            pass.Name = "Oleg";
            pass.PhoneNumber = "0663575855";

            Expect.Call(sut.GetPassenger(id)).Return(pass);
            repo.ReplayAll();
            Assert.True(pass.Equals(sut.GetPassenger(id)));
            repo.VerifyAll();
        }

        [Fact]
        public void GetPassengerShouldReturnNull()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 10;
            Passenger pass = null;

            Expect.Call(sut.GetPassenger(id)).Return(pass);
            repo.ReplayAll();
            Assert.Null(sut.GetPassenger(id));
            repo.VerifyAll();

        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldAddOrder(bool expected)
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            Order o = new Order(id);
            o.Address = "Golosyivskiy, 120B";
            o.Location = "50.386157, 30.484798";
            o.DateAndTime = DateTime.Now.AddHours(1);
            o.PassengerId = 3;

            Expect.Call(sut.AddOrder(o)).Return(expected);
            repo.ReplayAll();
            Assert.Equal(expected, sut.AddOrder(o));
            repo.VerifyAll();

        }

        [Fact]
        public void GetAllOrdersShouldReturnCollection()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            Order o = new Order(id);
            o.Address = "Golosyivskiy, 120B";
            o.Location = "50.386157, 30.484798";
            o.DateAndTime = DateTime.Now.AddHours(1);
            o.PassengerId = 3;

            List<Order> orders = new List<Order>() { o };

            Expect.Call(sut.GetAllOrders()).Return(orders).Repeat.Times(3);
            repo.ReplayAll();
            Assert.NotNull(sut.GetAllOrders());
            Assert.NotEmpty(sut.GetAllOrders());
            Assert.IsType<List<Order>>(sut.GetAllOrders());

            repo.VerifyAll();


        }

        [Fact]
        public void GetAllOrdersShouldReturnNull()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            List<Order> orders = null;

            Expect.Call(sut.GetAllOrders()).Return(orders);
            repo.ReplayAll();

            Assert.Null(sut.GetAllOrders());

            repo.VerifyAll();
        }            

        [Fact]
        public void GetOrderShouldReturnOrder()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();
            int id = 1;
            Order o = new Order(id);
            o.Address = "Golosyivskiy, 120B";
            o.Location = "50.386157, 30.484798";
            o.DateAndTime = DateTime.Now.AddHours(1);
            o.PassengerId = 3;

            Expect.Call(sut.GetOrder(id)).Return(o);
            repo.ReplayAll();
            Assert.True(o.Equals(sut.GetOrder(id)));
            repo.VerifyAll();            

        }

        [Fact]
        public void GetOrderShouldRetunNull()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 10;
            Order o = null;

            Expect.Call(sut.GetOrder(id)).Return(o);
            repo.ReplayAll();
            Assert.Null(sut.GetOrder(id));
            repo.VerifyAll();

        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldAddDriverInCar(bool expected)
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            DriverInCar dIC = new DriverInCar(id);
            dIC.CarId = 3;
            dIC.DriverId = 3;
            dIC.Address = "Akademika Glushkova 12A";
            dIC.Location = "50.374211, 30.462582";

            Expect.Call(sut.AddDriverInCar(dIC)).Return(expected);
            repo.ReplayAll();
            Assert.Equal(expected, sut.AddDriverInCar(dIC));
            repo.VerifyAll();

        }

        [Fact]
        public void GetAllDriversInCarsShouldReturnCollection()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            DriverInCar dIC = new DriverInCar(id);
            dIC.CarId = 3;
            dIC.DriverId = 3;
            dIC.Address = "Akademika Glushkova 12A";
            dIC.Location = "50.374211, 30.462582";

            List<DriverInCar> driversInCars = new List<DriverInCar>() { dIC };

            Expect.Call(sut.GetAllDriversInCars()).Return(driversInCars).Repeat.Times(3);
            repo.ReplayAll();
            Assert.NotNull(sut.GetAllDriversInCars());
            Assert.NotEmpty(sut.GetAllDriversInCars());
            Assert.IsType<List<DriverInCar>>(sut.GetAllDriversInCars());
            repo.VerifyAll();

        }

        [Fact]
        public void GetAllDriversInCarsShouldReturnNull()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            List<DriverInCar> driversInCars = null;

            Expect.Call(sut.GetAllDriversInCars()).Return(driversInCars);
            repo.ReplayAll();
            Assert.Null(sut.GetAllDriversInCars());
            repo.VerifyAll();

        }

        [Fact]
        public void GetDriverInCarShouldReturnDriverInCar()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 1;
            DriverInCar dIC = new DriverInCar(id);
            dIC.CarId = 3;
            dIC.DriverId = 3;
            dIC.Address = "Akademika Glushkova 12A";
            dIC.Location = "50.374211, 30.462582";

            
            Expect.Call(sut.GetDriverInCar(id)).Return(dIC);
            repo.ReplayAll();
            Assert.True(dIC.Equals(sut.GetDriverInCar(id)));
            repo.VerifyAll();
            
        }

        [Fact]
        public void GetDriverInCarShouldReturnNull()
        {
            MockRepository repo = new MockRepository();
            ITaxiDataRepository sut = repo.StrictMock<Linq2SqlTaxiDataRepository>();

            int id = 10;
            DriverInCar dIC = null;


            Expect.Call(sut.GetDriverInCar(id)).Return(dIC);
            repo.ReplayAll();
            Assert.Null(sut.GetDriverInCar(id));
            repo.VerifyAll();

        }
    }
}
