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
            var cat = Db.Categories.First();
            Db.Database.ExecuteSqlCommand("Update Store.Categories set CategoryName = 'Bar'");
            cat.CategoryName = "FooBar";

            var ex = Assert.Throws<DbUpdateConcurrencyException>(() => Db.SaveChanges());

            //Database wins
            //ex.Entries.Single().Reload();

            //Client wins
            //var entry = ex.Entries.Single();
            //entry.OriginalValues.SetValues(entry.GetDatabaseValues());

            //Custom Scenario
            var entry = ex.Entries.Single();
            var originalValues = entry.OriginalValues;
            var originalCatName = originalValues[nameof(cat.CategoryName)];
            var currentValues = entry.CurrentValues;
            var currentName = currentValues[nameof(cat.CategoryName)];
            var databaseValues = entry.GetDatabaseValues();
            var databaseName = databaseValues[nameof(cat.CategoryName)];

            Assert.Equal("Foo", originalCatName);
            Assert.Equal("Bar", databaseName);
            Assert.Equal("FooBar", currentName);
        }
    }
}
