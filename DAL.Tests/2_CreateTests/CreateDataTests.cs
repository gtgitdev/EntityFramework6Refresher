using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Tests.Helpers;
using Xunit;

namespace DAL.Tests.CreateTests
{
    [Collection(Constants.CollectionName)]
    public class CreateDataTests : BaseTest
    {

        [Fact]
        public void ShouldAddCategory()
        {
            var count = Db.Categories.Count();
            Assert.Equal(0, count);

            var cat = new Category { CategoryName = "Foo" };
            Assert.Equal(0, cat.Id);
            Assert.Null(cat.TimeStamp);

            Db.Categories.Add(cat);
            Db.SaveChanges();

            Assert.NotEqual(0, cat.Id);
            Assert.NotNull(cat.TimeStamp);
            Assert.Equal(8, cat.TimeStamp.Length);

            Assert.Equal(count + 1, Db.Categories.Count());
            var newCat = Db.Categories.FirstOrDefault(c => c.Id == cat.Id);
            Assert.Equal(cat.CategoryName, newCat?.CategoryName);

        }

        [Fact]
        public void ShouldAddTwoCategories()
        {
            var count = Db.Categories.Count();

            var cat1 = new Category { CategoryName = "Foo" };
            var cat2 = new Category { CategoryName = "Bar" };

            Db.Categories.AddRange(new List<Category> { cat1, cat2 });
            Db.SaveChanges();

            Assert.Equal(count + 2, Db.Categories.Count());


        }

        [Fact]
        public void ShouldAddCategoryAndProducts()
        {
            var prodCount = Db.Products.Count();
            var cat = new Category { CategoryName = "Foo" };

            cat.Products.Add(new Product { ModelName = "Foo" });
            cat.Products.Add(new Product { ModelName = "Bar" });
            cat.Products.Add(new Product { ModelName = "FooBar" });

            Db.Categories.Add(cat);
            Db.SaveChanges();

            Assert.Equal(prodCount + 3, Db.Products.Count());


        }

    }
}
