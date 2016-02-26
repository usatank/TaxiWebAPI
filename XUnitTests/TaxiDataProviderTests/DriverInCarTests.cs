using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using TaxiDataProvider.EntitiesLinq2Sql;

namespace XUnitTests.TaxiDataProviderTests
{
    public class DriverInCarFixture : IDisposable
    {
        public DriverInCar Sut { get; set; }

        public DriverInCarFixture()
        {
            Sut = new DriverInCar();
        }

        public void Dispose()
        {
            Sut.Dispose();
        }
    }

    [Trait("Category", "DriverInCar Tests")]
    public class DriverInCarTests : IClassFixture<DriverInCarFixture>
    {
        private DriverInCarFixture _fixture;

        public DriverInCarTests(DriverInCarFixture fixture)
        {
            this._fixture = fixture;
        }

        [Fact]
        public void SholdGetId()
        {
            int expected = 1;
            Assert.Equal(expected, _fixture.Sut.Id);
        }

        [Theory]
        [InlineData("1", "1")]
        [InlineData("100", "100")]
        public void ShouldGetSetCarId(int value, int expected)
        {
            _fixture.Sut.CarId = value;
            Assert.Equal(expected, _fixture.Sut.CarId);
        }

        [Theory]
        [InlineData("1", "1")]
        [InlineData("100", "100")]
        public void ShouldGetSetDriverId(int value, int expected)
        {
            _fixture.Sut.DriverId = value;
            Assert.Equal(expected, _fixture.Sut.DriverId);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Lugova 12", "Lugova 12")]
        [InlineData("Peremogy 50", "Peremogy 50")]
        public void ShouldGetSetAddress(string value, string expected)
        {
            _fixture.Sut.Address = value;
            Assert.Equal(expected, _fixture.Sut.Address);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("50.394932, 30.478699", "50.394932, 30.478699")]
        [InlineData("50.388596, 30.490075", "50.388596, 30.490075")]
        public void ShouldGetSetLocation(string value, string expected)
        {
            _fixture.Sut.Location = value;
            Assert.Equal(expected, _fixture.Sut.Location);
        }

    }
}
