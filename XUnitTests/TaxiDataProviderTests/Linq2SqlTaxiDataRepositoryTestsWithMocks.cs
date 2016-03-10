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
        }
    }
}
