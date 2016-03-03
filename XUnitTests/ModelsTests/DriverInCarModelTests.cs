using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using TaxiDataProvider.EntitiesLinq2Sql;
using TaxiWebAPI.Models;

namespace XUnitTests.ModelsTests
{
    public class DriverInCarFixture : IDisposable
    {
        public DriverInCar dIC { get; set; }
        public DriverInCarModel Sut { get; set; }

        public DriverInCarFixture()
        {
            dIC = new DriverInCar() { Address = "Peremogy, 50", CarId = 1, DriverId = 1, Location = "50.456487, 30.444342" , Driver = new Driver() { FirstName = "Andrii", LastName = "Ivanov", HomeAddress = "Lugova, 12", PhoneNumber = "0661234567" }, Car = new Car() { Brand = "Lifan", Model = "620", Number = "AA2345CH" } };
            Sut = new DriverInCarModel(dIC);

        }

        public void Dispose()
        {
            dIC.Dispose();
            Sut.Dispose();
        }

    }


    [Trait("Category", "DriverInCarModel Tests")]
    public class DriverInCarModelTests : IClassFixture<DriverInCarFixture>
    {
        private DriverInCarFixture _fixture;

        public DriverInCarModelTests(DriverInCarFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldGetId()
        {
            Assert.Equal(_fixture.dIC.Id, _fixture.Sut.Id);
        }

        [Fact]
        public void ShouldGetSetCarId()
        {
            int carIdExp = 5;
            _fixture.Sut.CarId = carIdExp;
            Assert.Equal(carIdExp, _fixture.Sut.CarId);

        }
                        
    
    }
}
