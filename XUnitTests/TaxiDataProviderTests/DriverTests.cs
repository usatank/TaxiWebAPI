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
    public class DriverFixture : IDisposable
    {
        public Driver Sut { get; set; }

        public DriverFixture()
        {
            Sut = new Driver();
        }

        public void Dispose()
        {
            Sut.Dispose();
        }

    }

    [Trait("Category", "Driver Tests")]
    public class DriverTests : IClassFixture<DriverFixture>
    {
        private DriverFixture _fixture;

        public DriverTests(DriverFixture fixture)
        {
            this._fixture = fixture;
        }

        [Fact]
        public void ShouldGetId()
        {
            int expected = 1;
            _fixture.Sut = new Driver(expected);
            Assert.Equal(expected, _fixture.Sut.Id);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Andrii", "Andrii")]
        [InlineData("Sergii", "Sergii")]
        public void ShouldGetSetFirstName(string value, string expected)
        {
            _fixture.Sut.FirstName = value;
            Assert.Equal(expected, _fixture.Sut.FirstName);

        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Ivanov", "Ivanov")]
        [InlineData("Petrov", "Petrov")]
        public void ShouldGetSetLastName(string value, string expected)
        {
            _fixture.Sut.LastName = value;
            Assert.Equal(expected, _fixture.Sut.LastName);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("0501234567", "0501234567")]
        [InlineData("0975431236", "0975431236")]
        public void ShouldGetSetPhoneNumber(string value, string expected)
        {
            _fixture.Sut.PhoneNumber = value;
            Assert.Equal(expected, _fixture.Sut.PhoneNumber);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Lugova 12", "Lugova 12")]
        [InlineData("Peremogy 50", "Peremogy 50")]
        public void ShouldGetSetHomeAddress(string value, string expected)
        {
            _fixture.Sut.HomeAddress = value;
            Assert.Equal(expected, _fixture.Sut.HomeAddress);
        }

        [Fact]
        public void EqualsShoulreturnTrue()
        {
            Driver d1 = new Driver() { FirstName = "Andrii", LastName = "Ivanov", HomeAddress = "Lugova, 12", PhoneNumber = "0661234567" };
            Driver d2 = new Driver() { FirstName = "Andrii", LastName = "Ivanov", HomeAddress = "Lugova, 12", PhoneNumber = "0661234567" };

            Assert.True(d1.Equals(d2));
            Assert.True(d2.Equals(d1));
            Assert.True(d1.Equals(d1));
            Assert.True(d2.Equals(d2));
        }

        [Fact]
        public void EqualsShouldReturnFalse()
        {
            Driver d1 = new Driver() { FirstName = "Andrii", LastName = "Ivanov", HomeAddress = "Lugova, 12", PhoneNumber = "0661234567" };
            Driver d2 = new Driver() { FirstName = "Serhii", LastName = "Ivanov", HomeAddress = "Lugova, 12", PhoneNumber = "0661234567" };
            Driver d3 = new Driver() { FirstName = "Andrii", LastName = "Petrov", HomeAddress = "Lugova, 12", PhoneNumber = "0661234567" };
            Driver d4 = new Driver() { FirstName = "Andrii", LastName = "Ivanov", HomeAddress = "Lugova, 15", PhoneNumber = "0661234567" };
            Driver d5 = new Driver() { FirstName = "Andrii", LastName = "Ivanov", HomeAddress = "Lugova, 12", PhoneNumber = "0661234577" };

            Assert.False(d1.Equals(d2));
            Assert.False(d1.Equals(d3));
            Assert.False(d1.Equals(d4));
            Assert.False(d1.Equals(d5));
        }
    }


}
