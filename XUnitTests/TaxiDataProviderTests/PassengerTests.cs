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

    public class PassengerFixture : IDisposable
    {
        public Passenger Sut { get; set; }

        public PassengerFixture()
        {
            Sut = new Passenger();
        }

        public void Dispose()
        {
            Sut.Dispose();
        }
    }


    [Trait("Category", "Passenger Tests")]
    public class PassengerTests : IClassFixture<PassengerFixture>
    {
        private PassengerFixture _fixture;

        public PassengerTests(PassengerFixture fixture)
        {
            this._fixture = fixture;
        }

        [Fact]
        public void ShouldGetId()
        {
            int expected = 1;
            Assert.Equal(expected, _fixture.Sut.Id);

        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Andrii", "Andrii")]
        [InlineData("Sergii", "Sergii")]
        public void ShouldGetSetName(string value, string expected)
        {
            _fixture.Sut.Name = value;
            Assert.Equal(expected, _fixture.Sut.Name);

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

        [Fact]
        public void EqualsShouldReturnTrue()
        {
            Passenger p1 = new Passenger() { Name = "Andrii", PhoneNumber = "0991234567"};
            Passenger p2 = new Passenger() { Name = "Andrii", PhoneNumber = "0991234567" };

            Assert.True(p1.Equals(p2));
            Assert.True(p1.Equals(p1));
            Assert.True(p2.Equals(p1));
            Assert.True(p2.Equals(p2));
        }

        [Fact]
        public void EqualsShouldReturnFalse()
        {
            Passenger p1 = new Passenger() { Name = "Andrii", PhoneNumber = "0991234567" };
            Passenger p2 = new Passenger() { Name = "Sergii", PhoneNumber = "0991234567" };
            Passenger p3 = new Passenger() { Name = "Andrii", PhoneNumber = "0992234567" };

            Assert.False(p1.Equals(p2));
            Assert.False(p1.Equals(p3));
        }

    }
}
