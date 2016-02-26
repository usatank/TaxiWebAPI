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

    }


}
