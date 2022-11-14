using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;


namespace ASPNetServer.Data
{
    internal sealed class AppDBContext : DbContext
    {     
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDb.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OrderDetail[] orderDetailsToSeed = new OrderDetail[7];
            for (int i = 0; i <= 7; i++)
            {
                orderDetailsToSeed[i - 1] = new OrderDetail
                {
                    OrderDetailId = i,
                    Total=10,
                    ProductName= $"Total{i}",
                    ProductQuantity=100,
                    ProductPrice=500,
                    OrderingCompanyName = "SÜTİŞ",
                    OrderDate = DateTime.Now                    
                };
            }
            modelBuilder.Entity<OrderDetail>().HasData(orderDetailsToSeed);
        }

    }
}
