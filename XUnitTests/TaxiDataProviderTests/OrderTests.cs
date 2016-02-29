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
    public class OrderFixture : IDisposable
    {
        public Order Sut { get; set; }

        public OrderFixture()
        {
            Sut = new Order();
        }

        public void Dispose()
        {
            Sut.Dispose();
        }
    }


    [Trait("Category", "Order Tests")]
    public class OrderTests : IClassFixture<OrderFixture>
    {
        private OrderFixture _fixture;

        public OrderTests(OrderFixture fixture)
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

        [Fact]
        public void ShouldGetSetDateAndTime()
        {
            DateTime dateTime = DateTime.Now;
            _fixture.Sut.DateAndTime = dateTime;
            Assert.Equal(dateTime, _fixture.Sut.DateAndTime);

            dateTime = DateTime.Now.AddDays(2);
            _fixture.Sut.DateAndTime = dateTime;
            Assert.Equal(dateTime, _fixture.Sut.DateAndTime);
        }


        [Theory]
        [InlineData("1", "1")]
        [InlineData("100", "100")]
        public void ShouldGetSetPassengerId(int value, int expected)
        {
            _fixture.Sut.PassengerId = value;
            Assert.Equal(expected, _fixture.Sut.PassengerId);
        }

        [Fact]
        public void EqualsShouldReturnTrue()
        {
            var dateTime = DateTime.Now.AddDays(2);
            Order o1 = new Order() {Address = "Peremogy, 50", Location = "50.456487, 30.444342", DateAndTime = dateTime, PassengerId = 1 };
            Order o2 = new Order() { Address = "Peremogy, 50", Location = "50.456487, 30.444342", DateAndTime = dateTime, PassengerId = 1 };

            Assert.True(o1.Equals(o2));
            Assert.True(o1.Equals(o1));
            Assert.True(o2.Equals(o1));
            Assert.True(o2.Equals(o2));
        }

        [Fact]
        public void EqualsShouldReturnFalse()
        {
            var dateTime = DateTime.Now.AddDays(2);
            Order o1 = new Order() { Address = "Peremogy, 50", Location = "50.456487, 30.444342", DateAndTime = dateTime, PassengerId = 1 };
            Order o2 = new Order() { Address = "Peremogy, 51", Location = "50.456487, 30.444342", DateAndTime = dateTime, PassengerId = 1 };
            Order o3 = new Order() { Address = "Peremogy, 50", Location = "50.456477, 30.444342", DateAndTime = dateTime, PassengerId = 1 };
            Order o4 = new Order() { Address = "Peremogy, 50", Location = "50.456487, 30.444342", DateAndTime = dateTime.AddMinutes(1), PassengerId = 1 };
            Order o5 = new Order() { Address = "Peremogy, 50", Location = "50.456487, 30.444342", DateAndTime = dateTime, PassengerId = 2 };

            Assert.False(o1.Equals(o2));
            Assert.False(o1.Equals(o3));
            Assert.False(o1.Equals(o4));
            Assert.False(o1.Equals(o5));
        }


    }
}
