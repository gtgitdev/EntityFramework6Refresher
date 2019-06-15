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
            var cat = Db.Categories.First();
            cat.CategoryName = "Bar";
            Db.SaveChanges();

            var updatedCat = new IntroToEfContext().Categories.First();
            Assert.Equal("Bar", updatedCat.CategoryName);



        }
        [Fact]
        public void ShouldProductModelName()
        {
            var cat = Db.Categories.Include(c => c.Products).First();
            var modelName = "Foo";

            cat.Products.ToList()[0].ModelName = modelName;
            Db.SaveChanges();

            var cat2 = new IntroToEfContext().Categories.Include(c => c.Products).First();

            Assert.Equal(modelName, cat2.Products.ToList()[0].ModelName);

        }
    }
}
