using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DAL.EF;
using DAL.Tests.Helpers;
using Xunit;

namespace DAL.Tests.UpdateTests
{
    [Collection(Constants.CollectionName)]
    public class UpdateDataTests : BaseTest
    {
        public UpdateDataTests()
        {
            AddRecords.AddCategory(Db, "Foo");
            AddRecords.AddProduct(Db, 2, 100, "New Product", "Name", "Number", 90, 5);
            AddRecords.AddProduct(Db, 2, 20, "New Product2", "Name2", "Number2", 10, 15);

        }

        [Fact]
        public void ShouldUpdateCategoryName()
        {
        }
        [Fact]
        public void ShouldProductModelName()
        {
        }
    }
}
