using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiWebAPI.Models;
using TaxiDataProvider.EntitiesLinq2Sql;
using Xunit;
using Xunit.Abstractions;


namespace XUnitTests.ModelsTests
{
    public class CarModelFixture : IDisposable
    {
        public CarModel Sut { get; set; }
        public Car Car { get; set; }

        public CarModelFixture()
        {
            Car = new Car() { Brand = "Lifan", Model = "620", Number = "AA2345CH" };
            Sut = new CarModel(Car);
                        
        }

        public void Dispose()
        {
            Sut.Dispose();
            Car.Dispose();
        }
    }

    [Trait("Category", "CarModel Tests")]
    public class CarModelTests : IClassFixture<CarModelFixture>
    {
        private CarModelFixture _fixture;

        public CarModelTests(CarModelFixture fixture)
        {
            this._fixture = fixture;
        }


        [Fact]
        public void ShouldGetId()
        {
            Assert.Equal(_fixture.Car.Id, _fixture.Sut.Id);
        }

        [Fact]
        public void ShouldGetSetBrand()
        {
            string brandExpected = "Audi";
            _fixture.Sut.Brand = brandExpected;
            Assert.Equal(brandExpected, _fixture.Sut.Brand);

        }

        [Fact]
        public void ShouldGetSetModel()
        {
            string modelExpected = "Q7";
            _fixture.Sut.Model = modelExpected;
            Assert.Equal(modelExpected, _fixture.Sut.Model);
        }

        [Fact]
        public void ShouldGetSetNumber()
        {
            string numberExpected = "AA0000AA";
            _fixture.Sut.Number = numberExpected;
            Assert.Equal(numberExpected, _fixture.Sut.Number);
        }

        [Fact]
        public void ShouldCreateModel()
        {
            _fixture.Sut = new CarModel(_fixture.Car);
            Assert.Equal(_fixture.Car.Id, _fixture.Sut.Id);
            Assert.Equal(_fixture.Car.Brand, _fixture.Sut.Brand);
            Assert.Equal(_fixture.Car.Model, _fixture.Sut.Model);
            Assert.Equal(_fixture.Car.Number, _fixture.Car.Number);

        }

    }
}
