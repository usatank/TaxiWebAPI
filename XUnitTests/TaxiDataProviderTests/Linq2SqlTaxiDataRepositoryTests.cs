using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDataProvider;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTests.TaxiDataProviderTests
{
    public class Linq2SqlTaxiDataRepositoryFixture : IDisposable
    {
        Linq2SqlTaxiDataRepository Sut { get; set; }

        public Linq2SqlTaxiDataRepositoryFixture()
        {
            this.Sut = new Linq2SqlTaxiDataRepository();
        }

        public void Dispose()
        {
            Sut.Dispose();
        }
    }

    [Trait("Category", "Linq2SqlTaxiDataRepository Tests")]
    public class Linq2SqlTaxiDataRepositoryTests : IClassFixture<Linq2SqlTaxiDataRepository>
    {

    }
}
