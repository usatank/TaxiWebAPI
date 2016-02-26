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
        public void ShouldGetIt()
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



    }
}
