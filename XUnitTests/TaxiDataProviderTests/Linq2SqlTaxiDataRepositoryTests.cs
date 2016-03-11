//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TaxiDataProvider;
//using Xunit;
//using System.Reflection;
//using Xunit.Abstractions;
//using TaxiDataProvider.EntitiesLinq2Sql;

//namespace XUnitTests.TaxiDataProviderTests
//{
//    public class Linq2SqlTaxiDataRepositoryFixture : IDisposable
//    {
//        public Linq2SqlTaxiDataRepository Sut { get; set; }
//        public Linq2SqlTaxiDataRepository SutWithoutConnectionString { get; set; }

//        public Linq2SqlTaxiDataRepositoryFixture()
//        {
//            this.Sut = new Linq2SqlTaxiDataRepository();
//            //setting connection string for tests
//            typeof(Linq2SqlTaxiDataRepository).GetField("_connectionString", BindingFlags.Instance | BindingFlags.NonPublic)
//                .SetValue(this.Sut, @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=D:\ANDRII\LEVI9\ACADEMY\REPOSITORY\TAXIWEBAPI\TAXIWEBAPI\APP_DATA\TAXIDATABASE.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

//            this.SutWithoutConnectionString = new Linq2SqlTaxiDataRepository();
//            //emulating empty connection string
//            typeof(Linq2SqlTaxiDataRepository).GetField("_connectionString", BindingFlags.Instance | BindingFlags.NonPublic)
//                .SetValue(this.SutWithoutConnectionString, String.Empty);
//        }

//        public void Dispose()
//        {
//            Sut.Dispose();
//            SutWithoutConnectionString.Dispose();
//        }
//    }

//    [Trait("Category", "Linq2SqlTaxiDataRepository Tests")]
//    public class Linq2SqlTaxiDataRepositoryTests : IClassFixture<Linq2SqlTaxiDataRepositoryFixture>
//    {
//        private Linq2SqlTaxiDataRepositoryFixture _fixture;

//        public Linq2SqlTaxiDataRepositoryTests(Linq2SqlTaxiDataRepositoryFixture fixture)
//        {
//            this._fixture = fixture;

//        }

//        [Fact]
//        public void AddCarShouldReturnTrue()
//        {
//            int countBeforeAdding = _fixture.Sut.GetAllCars().Count;
//            Assert.True(_fixture.Sut.AddCar(new Car() { Brand = "Volkswagen", Model = "Polo Sedan", Number = "AI1234AT" }));
//            int countAfterAdding = _fixture.Sut.GetAllCars().Count;
//            Assert.Equal(countBeforeAdding + 1, countAfterAdding);
//        }

//        [Fact]
//        public void AddCarShouldReturnFalse()
//        {
//            Assert.False(_fixture.SutWithoutConnectionString.AddCar(new Car() { Brand = "GAZ", Model = "31105", Number = "AT2356CH" }));
//        }

//        [Fact]
//        public void GetAllCarsShouldReturnNull()
//        {
//            Assert.Null(_fixture.SutWithoutConnectionString.GetAllCars());
//        }

//        [Fact]
//        public void GetAllCarsShouldReturnCollection()
//        {
//            _fixture.Sut.AddCar(new Car() { Brand = "Volkswagen", Model = "Polo Sedan", Number = "AA4512AT" });
//            var cars = _fixture.Sut.GetAllCars();
//            Assert.NotNull(cars);
//            Assert.NotEmpty(cars);
//            Assert.IsType<List<Car>>(cars);
//        }

//        [Fact]
//        public void GetCarShouldReturnNull()
//        {
//            Assert.Null(_fixture.SutWithoutConnectionString.GetCar(1));
//            Assert.Null(_fixture.Sut.GetCar(-2));
//            Assert.Null(_fixture.Sut.GetCar(int.MaxValue));
//        }

//        [Fact]
//        public void GetCarShouldReturnCar()
//        {
//            Car carExpected = new Car() { Brand = "Volkswagen", Model = "Polo Sedan", Number = "AA4512AT" };
//            _fixture.Sut.AddCar(carExpected);
//            int carId = carExpected.Id;
//            var carActual = _fixture.Sut.GetCar(carId);
//            Assert.NotNull(carActual);
//            Assert.IsType<Car>(carActual);
//            Assert.True(carExpected.Equals(carActual));

//        }

//        [Fact]
//        public void AddDriverShouldReturnTrue()
//        {
//            int countBeforeAdding = _fixture.Sut.GetAllDrivers().Count;
//            Assert.True(_fixture.Sut.AddDriver(new Driver() { FirstName = "Oleksandr", LastName = "Sidorov", HomeAddress = "Peremogy, 50", PhoneNumber = "0507854312" }));
//            int countAfterAdding = _fixture.Sut.GetAllDrivers().Count;
//            Assert.Equal(countBeforeAdding + 1, countAfterAdding);
//        }



//        [Fact]
//        public void AddDriverShouldReturnFalse()
//        {
//            Assert.False(_fixture.SutWithoutConnectionString.AddDriver(new Driver() { FirstName = "Oleksii", LastName = "Smirnov", HomeAddress = "Lugova 20", PhoneNumber = "0978941326" }));

//        }

//        [Fact]
//        public void GetAllDriversShouldReturnNull()
//        {
//            Assert.Null(_fixture.SutWithoutConnectionString.GetAllDrivers());
//        }


//        [Fact]
//        public void GetAllDriversShouldReturnCollection()
//        {
//            _fixture.Sut.AddDriver(new Driver() { FirstName = "Oleksandr", LastName = "Sidorov", HomeAddress = "Peremogy, 50", PhoneNumber = "0507854312" });
//            var drivers = _fixture.Sut.GetAllDrivers();
//            Assert.NotNull(drivers);
//            Assert.NotEmpty(drivers);
//            Assert.IsType<List<Driver>>(drivers);
//        }



//        [Fact]
//        public void GetDriverShouldReturnNull()
//        {
//            Assert.Null(_fixture.SutWithoutConnectionString.GetDriver(1));
//            Assert.Null(_fixture.Sut.GetDriver(-2));
//            Assert.Null(_fixture.Sut.GetDriver(int.MaxValue));
//        }

//        [Fact]
//        public void GetDriverShouldReturnDriver()
//        {
//            Driver driverExpected = new Driver() { FirstName = "Oleksandr", LastName = "Sidorov", HomeAddress = "Peremogy, 50", PhoneNumber = "0507854312" };
//            _fixture.Sut.AddDriver(driverExpected);
//            int driverId = driverExpected.Id;
//            var driverActual = _fixture.Sut.GetDriver(driverId);

//            Assert.NotNull(driverActual);
//            Assert.IsType<Driver>(driverActual);
//            Assert.True(driverExpected.Equals(driverActual));

//        }

//        [Fact]
//        public void AddPassengerShouldReturnTrue()
//        {
//            int countBeforeAdding = _fixture.Sut.GetAllPassengers().Count;
//            Assert.True(_fixture.Sut.AddPassenger(new Passenger() { Name = "Oleg", PhoneNumber = "0663575855" }));
//            int countAfterAdding = _fixture.Sut.GetAllPassengers().Count;
//            Assert.Equal(countBeforeAdding + 1, countAfterAdding);
//        }

//        [Fact]
//        public void AddPassengerShouldReturnFalse()
//        {
//            Assert.False(_fixture.SutWithoutConnectionString.AddPassenger(new Passenger() { Name = "Oleg", PhoneNumber = "0663575855" }));
//        }

//        [Fact]
//        public void GetAllPassengersShouldReturnNull()
//        {
//            Assert.Null(_fixture.SutWithoutConnectionString.GetAllPassengers());
//        }

//        [Fact]
//        public void GetAllPassengersShouldReturnCollection()
//        {
//            _fixture.Sut.AddPassenger(new Passenger() { Name = "Oleg", PhoneNumber = "0663575855" });
//            var passengers = _fixture.Sut.GetAllPassengers();

//            Assert.NotNull(passengers);
//            Assert.NotEmpty(passengers);
//            Assert.IsType<List<Passenger>>(passengers);

//        }

//        [Fact]
//        public void GetPassengerShouldReturnNull()
//        {
//            Assert.Null(_fixture.SutWithoutConnectionString.GetPassenger(1));
//            Assert.Null(_fixture.Sut.GetPassenger(-10));
//            Assert.Null(_fixture.Sut.GetPassenger(int.MaxValue));
//        }

//        [Fact]
//        public void GetPassengerShouldReturnPassenger()
//        {
//            Passenger passengerExpected = new Passenger() { Name = "Oleg", PhoneNumber = "0663575855" };
//            _fixture.Sut.AddPassenger(passengerExpected);
//            int passengerId = passengerExpected.Id;

//            var passengerActual = _fixture.Sut.GetPassenger(passengerId);

//            Assert.NotNull(passengerActual);
//            Assert.IsType<Passenger>(passengerActual);
//            Assert.True(passengerExpected.Equals(passengerActual));
//        }


//        [Fact]
//        public void AddOrderShouldReturnTrue()
//        {
//            int countBeforeAdding = _fixture.Sut.GetAllOrders().Count;
//            Assert.True(_fixture.Sut.AddOrder(new Order() { Address = "Golosyivskiy, 120B", Location = "50.386157, 30.484798", DateAndTime = DateTime.Now.AddHours(1), PassengerId = 3 }));
//            int countAfterAdding = _fixture.Sut.GetAllOrders().Count;
//            Assert.Equal(countBeforeAdding + 1, countAfterAdding);

//        }

//        [Fact]
//        public void AddOrderShouldReturnFalse()
//        {
//            Assert.False(_fixture.SutWithoutConnectionString.AddOrder(new Order() { Address = "Golosyivskiy, 120B", Location = "50.386157, 30.484798", DateAndTime = DateTime.Now.AddHours(1), PassengerId = 3 }));
//        }

//        [Fact]
//        public void GetAllOrdersShouldReturnNull()
//        {
//            Assert.Null(_fixture.SutWithoutConnectionString.GetAllOrders());
//        }

//        [Fact]
//        public void GetAllOrdersShouldReturnCollection()
//        {
//            _fixture.Sut.AddOrder(new Order() { Address = "Golosyivskiy, 120B", Location = "50.386157, 30.484798", DateAndTime = DateTime.Now.AddHours(1), PassengerId = 3 });
//            var orders = _fixture.Sut.GetAllOrders();
//            Assert.NotNull(orders);
//            Assert.NotEmpty(orders);
//            Assert.IsType<List<Order>>(orders);
//        }

//        [Fact]
//        public void GetOrderShouldReturnNull()
//        {
//            Assert.Null(_fixture.SutWithoutConnectionString.GetOrder(1));
//            Assert.Null(_fixture.Sut.GetOrder(-10));
//            Assert.Null(_fixture.Sut.GetOrder(int.MaxValue));
//        }

//        [Fact]
//        public void GetOrderShouldReturnOrder()
//        {
//            Order orderExpected = new Order() { Address = "Golosyivskiy, 120B", Location = "50.386157, 30.484798", DateAndTime = DateTime.Now.AddHours(1), PassengerId = 3 };
//            _fixture.Sut.AddOrder(orderExpected);
//            int orderId = orderExpected.Id;
//            var orderActual = _fixture.Sut.GetOrder(orderId);

//            Assert.NotNull(orderActual);
//            Assert.IsType<Order>(orderActual);
//            Assert.True(orderExpected.Equals(orderActual));
//        }

//        [Fact]
//        public void AddDriverInCarShouldReturnTrue()
//        {
//            int countBeforeAdding = _fixture.Sut.GetAllDriversInCars().Count;
//            Assert.True(_fixture.Sut.AddDriverInCar(new DriverInCar() { CarId = 3, DriverId = 3, Address = "Akademika Glushkova 12A", Location = "50.374211, 30.462582" }));
//            int countAfterAdding = _fixture.Sut.GetAllDriversInCars().Count;
//            Assert.Equal(countBeforeAdding + 1, countAfterAdding);
                    
//        }

//        [Fact]
//        public void AddDriverInCarShouldReturnFalse()
//        {
//            Assert.False(_fixture.SutWithoutConnectionString.AddDriverInCar(new DriverInCar() { CarId = 3, DriverId = 3, Address = "Akademika Glushkova 12A", Location = "50.374211, 30.462582" }));
//        }

//        [Fact]
//        public void GetAllDriversInCarsShouldReturnNull()
//        {
//            Assert.Null(_fixture.SutWithoutConnectionString.GetAllDriversInCars());
//        }

//        [Fact]
//        public void GetAllDriversInCarsShouldReturnCollection()
//        {
//            _fixture.Sut.AddDriverInCar(new DriverInCar() { CarId = 3, DriverId = 3, Address = "Akademika Glushkova 12A", Location = "50.374211, 30.462582" });
//            var drivers = _fixture.Sut.GetAllDriversInCars();

//            Assert.NotNull(drivers);
//            Assert.NotEmpty(drivers);
//            Assert.IsType<List<DriverInCar>>(drivers);
//        }

//        [Fact]
//        public void GetDriverInCarShouldReturnNull()
//        {
//            Assert.Null(_fixture.SutWithoutConnectionString.GetDriverInCar(1));
//            Assert.Null(_fixture.Sut.GetDriverInCar(-10));
//            Assert.Null(_fixture.Sut.GetDriverInCar(int.MaxValue));
//        }

//        [Fact]
//        public void GetDriverInCarsShouldReturnDriverInCar()
//        {
//            DriverInCar dICExpected = new DriverInCar() { CarId = 3, DriverId = 3, Address = "Akademika Glushkova 12A", Location = "50.374211, 30.462582" };
//            _fixture.Sut.AddDriverInCar(dICExpected);
//            int dICId = dICExpected.Id;
//            var dICActual = _fixture.Sut.GetDriverInCar(dICId);

//            Assert.NotNull(dICActual);
//            Assert.IsType<DriverInCar>(dICActual);
//            Assert.True(dICExpected.Equals(dICActual));
//        }

//    }
//}
