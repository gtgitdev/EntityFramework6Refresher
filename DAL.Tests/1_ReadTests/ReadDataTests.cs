using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Tests.Helpers;
using Xunit;

namespace DAL.Tests.ReadTests
{
    [Collection(Constants.CollectionName)]
    public class ReadDataTests : BaseTest
    {

        public ReadDataTests()
        {
            AddRecords.AddCategory(Db, "Foo");
            AddRecords.AddCategory(Db, "Bar");
            AddRecords.AddCategory(Db, "FooBar");
            AddRecords.AddProduct(Db,2, 100, "New Product","Name", "Number", 90, 5);
            AddRecords.AddProduct(Db,2, 20, "New Product2","Name2", "Number2", 10, 15);
        }

        [Fact]
        public void ShouldGetAllCategories()
        {
            var list = Db.Categories;
            Assert.Equal(3, list.ToList().Count);
        }

        [Fact]
        public void ShouldGetFirstCategory()
        {
            var myId = 2;
            var cat = Db.Categories.FirstOrDefault(c => c.Id == myId);
            Assert.Equal(myId,cat?.Id);
        }

        [Fact]
        public void ShouldGetOneCategory()
        {
            var myId = 2;
            var cat = Db.Categories.Where(c => c.Id == myId).FirstOrDefault();
            Assert.Equal(myId, cat?.Id);
        }

        [Fact]
        public void ShouldFindOneCategory()
        {
            var myId = 2;
            var cat = Db.Categories.Find(2);
            Assert.Equal(myId, cat?.Id);

        }

        [Fact]
        public void ShouldGetAllProducts()
        {
            var myId = 2;
            var cat = Db.Categories.Find(2);
            Assert.Equal(myId,cat?.Products.Count);
            Assert.Equal("Name", cat?.Products.ToList()[0].ModelName);

        }
        [Fact]
        public void ShouldGetAllProductsWithCategory()
        {
            var myId = 2;
            var cat = Db.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == myId);
            Assert.Equal(myId, cat?.Products.Count);
            Assert.Equal("Name", cat?.Products.ToList()[0].ModelName);

        }
    }
}
