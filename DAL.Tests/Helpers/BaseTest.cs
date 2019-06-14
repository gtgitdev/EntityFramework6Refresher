using System;
using DAL.EF;

namespace DAL.Tests.Helpers
{
    public class BaseTest : IDisposable
    {
        protected readonly IntroToEfContext Db;

        public BaseTest()
        {
            Db = new IntroToEfContext();
        }

        public void Dispose()
        {
            Db.Database.ExecuteSqlCommand("delete from store.categories");
            Db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Store.Categories', RESEED, 1)");
            Db.Database.ExecuteSqlCommand("delete from store.products");
            Db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Store.Products', RESEED, 1)");
        }
    }
}