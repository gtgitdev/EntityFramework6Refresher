using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Tests.Helpers;
using Xunit;

namespace DAL.Tests.UpdateTests
{
    [Collection(Constants.CollectionName)]
    public class ConcurrencyTests : BaseTest
    {
        public ConcurrencyTests()
        {
            AddRecords.AddCategory(Db, "Foo");
        }

        [Fact]
        public void ShouldThrowConcurrencyError()
        {
        }
    }
}
