using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit;
using Utils;

namespace XUnitTests.UtilsTests
{
    [Trait("Category", "Assert Tests")]
    public class AssertTests
    {
        [Fact]
        public void IsNullShouldBeTrue()
        {
            Xunit.Assert.True(Utils.Assert.IsNull(null));
        }

        [Fact]
        public void IsNullShouldBeFalse()
        {
            Xunit.Assert.False(Utils.Assert.IsNull(new object()));
            int i = 0;
            Xunit.Assert.False(Utils.Assert.IsNull(i));
            string str = string.Empty;
            Xunit.Assert.False(Utils.Assert.IsNull(str));

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]        
        public void IsNullOrEmptyShouldBeTrue(string value)
        {
            Xunit.Assert.True(Utils.Assert.IsNullOrEmtpy(value));
        }

        [Theory]
        [InlineData("0")]
        [InlineData("\n")]
        [InlineData("some string")]
        public void IsNullOrEmptyShouldBeFalse(string value)
        {
            Xunit.Assert.False(Utils.Assert.IsNullOrEmtpy(value));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(200)]
        [InlineData(+6)]
        public void IsPositiveShouldBeTrue(int value)
        {
            Xunit.Assert.True(Utils.Assert.IsPositive(value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(2 - 6)]
        public void IsPositiveShouldBeFalse(int value)
        {
            Xunit.Assert.False(Utils.Assert.IsPositive(value));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\n")]
        [InlineData("   ")]
        public void IsNullOrEmptyOrWhitespaceShouldBeTrue(string value)
        {
            Xunit.Assert.True(Utils.Assert.IsNullOrEmtpyOrWhitespace(value));
        }

        [Theory]
        [InlineData("0")]
        [InlineData("Hello\n")]
        [InlineData("some string")]
        public void IsNullOrEmptyOrWhitespaceShouldBeFalse(string value)
        {
            Xunit.Assert.False(Utils.Assert.IsNullOrEmtpyOrWhitespace(value));
        }
    }
}
