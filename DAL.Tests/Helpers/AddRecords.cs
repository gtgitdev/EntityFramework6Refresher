using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.Tests.Helpers
{
    public static class AddRecords
    {
        public static void AddCategory(IntroToEfContext db, string categoryName)
        {
            db.Database.ExecuteSqlCommand($"INSERT INTO [Store].[Categories] ([CategoryName]) VALUES ('{categoryName}')");
        }
        public static void AddProduct(IntroToEfContext db, int categoryId, decimal price, string description, string modelName, string modelNumber, decimal unitCost, int quantity)
        {
            db.Database.ExecuteSqlCommand($"INSERT INTO [Store].[Products] ([CategoryId],[CurrentPrice],[Description],[IsFeatured],[ModelName],[ModelNumber],[UnitCost],[UnitsInStock]) VALUES ({categoryId}, {price}, '{description}',0,'{modelName}', '{modelNumber}', {unitCost}, {quantity})");

        }
    }
}
