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
        }

        [Fact]
        public void ShouldGetFirstCategory()
        {
        }

        [Fact]
        public void ShouldGetOneCategory()
        {
        }

        [Fact]
        public void ShouldFindOneCategory()
        {
        }

        [Fact]
        public void ShouldGetAllProducts()
        {
        }
        [Fact]
        public void ShouldGetAllProductsWithCategory()
        {
        }
    }
}
