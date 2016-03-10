using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDataProvider.EntitiesLinq2Sql;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTests.TaxiDataProviderTests
{
    public class CarFixture : IDisposable
    {
        public Car Sut { get; set; }

        public CarFixture()
        {
            Sut = new Car();
        }

        public void Dispose()
        {
            Sut.Dispose();
        }
    }

    [Trait("Category", "Car Tests")]
    public class CarTests : IClassFixture<CarFixture>
    {
        private readonly CarFixture _fixture;

        public CarTests(CarFixture fixture)
        {
            this._fixture = fixture;
        }

        [Fact]
        public void ShouldGetId()
        {
            int expected = 1;
            _fixture.Sut = new Car(expected);
            Assert.Equal(expected, _fixture.Sut.Id);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Kia", "Kia")]
        [InlineData("Hyundai", "Hyundai")]        
        public void ShouldSetGetBrand(string value, string expected)
        {
            _fixture.Sut.Brand = value;                       
            Assert.Equal(expected, _fixture.Sut.Brand);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Cerato", "Cerato")]
        [InlineData("Accent", "Accent")]
        public void ShouldSetGetModel(string value, string expected)
        {
            _fixture.Sut.Model = value;
            Assert.Equal(expected, _fixture.Sut.Model);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("AA0021CH", "AA0021CH")]
        [InlineData("AI8928AA", "AI8928AA")]
        public void ShouldSetGetNumber(string value, string expected)
        {
            _fixture.Sut.Number = value;
            Assert.Equal(expected, _fixture.Sut.Number);
        }

        [Fact]
        public void EqualsShouldReturnTrue()
        {
            Car car1 = new Car() { Brand = "Lifan", Model = "620", Number = "AA2345CH" };
            Car car2 = new Car() { Brand = "Lifan", Model = "620", Number = "AA2345CH" };
            Assert.True(car1.Equals(car2));
            Assert.True(car2.Equals(car1));
            Assert.True(car1.Equals(car1));
            Assert.True(car2.Equals(car2));
        }

        [Fact]
        public void EqualShouldReturnFalse()
        {
            Car car1 = new Car() { Brand = "Lifan", Model = "620", Number = "AA2345CH" };
            Car car2 = new Car() { Brand = "Lifan1", Model = "620", Number = "AA2345CH" };
            Car car3 = new Car() { Brand = "Lifan", Model = "6201", Number = "AA2345CH" };
            Car car4 = new Car() { Brand = "Lifan", Model = "620", Number = "AA5345CH" };
            Assert.False(car1.Equals(car2));
            Assert.False(car1.Equals(car3));
            Assert.False(car1.Equals(car3));
            Assert.False(car1.Equals(car4));            
        }
        
    }
}
