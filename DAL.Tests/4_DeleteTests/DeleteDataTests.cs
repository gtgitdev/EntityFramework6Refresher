using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DAL.EF;
using DAL.Tests.Helpers;
using Xunit;

namespace DAL.Tests.DeleteTests
{
    [Collection(Constants.CollectionName)]
    public class DeleteDataTests : BaseTest
    {

        public DeleteDataTests()
        {
            AddRecords.AddCategory(Db, "Foo");
            AddRecords.AddProduct(Db, 2, 100, "New Product", "Name", "Number", 90, 5);
            AddRecords.AddProduct(Db, 2, 20, "New Product2", "Name2", "Number2", 10, 15);
        }

        [Fact]
        public void ShouldDeleteCategory()
        {
            var catCount = Db.Categories.Count();
            var prodCount = Db.Products.Count();
            var cat = Db.Categories.First();
            Db.Categories.Remove(cat);
            Db.SaveChanges();

            Assert.Equal(catCount -1, Db.Categories.Count());
            Assert.Equal(prodCount-2, Db.Products.Count());
        }

        [Fact]
        public void ShouldDeleteWithEntityState()
        {
            //will fail if products loaded, better to use remove
            var catCount = Db.Categories.Count();
            var prodCount = Db.Products.Count();
            var cat = Db.Categories.First();
            Db.Entry(cat).State = EntityState.Deleted;
            Db.SaveChanges();
            Assert.Equal(catCount - 1, Db.Categories.Count());
            Assert.Equal(prodCount - 2, Db.Products.Count());

        }

        [Fact]
        public void ShouldDeleteCategoryById()
        {
            var catCount = Db.Categories.Count();
            var prodCount = Db.Products.Count();
            var cat = Db.Categories.First();

            var newDb = new IntroToEfContext();
            var catToDelete = new Category {Id = cat.Id, TimeStamp = cat.TimeStamp};

            newDb.Entry(catToDelete).State = EntityState.Deleted;

            newDb.SaveChanges();

            Assert.Equal(catCount - 1, Db.Categories.Count());
            Assert.Equal(prodCount - 2, Db.Products.Count());



        }
    }
}
