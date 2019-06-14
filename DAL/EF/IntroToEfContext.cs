namespace DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IntroToEfContext : DbContext
    {
        public IntroToEfContext()
            : base("name=IntroToEfContextConnectionString")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCartRecord> ShoppingCartRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.LineItemTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.CurrentPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ShoppingCartRecord>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();
        }
    }
}
